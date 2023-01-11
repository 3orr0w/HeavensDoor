using HeavensDoor.Helper;
using HeavensDoor.UserService;
using HeavensDoor.Views.Windows;
using HeavensDoorClass;
using MaterialDesignExtensions.Controls;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HeavensDoor.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientList.xaml
    /// </summary>
    public partial class ClientList : Page, INotifyPropertyChanged
    {
        private ObservableCollection<Client> filteredClients;
        private SortItem selectSort;
        private Client selectClient;
        private string selectType;
        private int currentPage;
        private int maxElemOnPage = 15;
        private string searchText;
        private bool orderByDescening;



        public ClientList()
        {
            LoadProducts();
            LoadSort();
            LoadType();
            InitializadeAll();

            InitializeComponent();
            DataContext = this;
        }
        public ObservableCollection<Client> Clients { get; set; }
        public SortItem SelectSort { get => selectSort; set { selectSort = value; OnPropertyChange(nameof(SelectSort)); FilteredList(SearchText, SelectType, SelectSort.Property, OrderByDescening); } }
        public Client SelectClient { get => selectClient; set { selectClient = value; OnPropertyChange(); } }
        public string SelectType { get => selectType; set { selectType = value; OnPropertyChange(nameof(SelectType)); FilteredList(SearchText, SelectType, SelectSort.Property, OrderByDescening); } }
        public int CurrentPage { get => currentPage; set { currentPage = value; FilteredList(SearchText, SelectType, SelectSort.Property, OrderByDescening); } }
        public string SearchText { get => searchText; set { searchText = value; OnPropertyChange(nameof(SearchText)); FilteredList(SearchText, SelectType, SelectSort.Property, OrderByDescening); } }
        public bool OrderByDescening { get => orderByDescening; set { orderByDescening = value; OnPropertyChange(nameof(OrderByDescening)); FilteredList(SearchText, SelectType, SelectSort.Property, OrderByDescening); } }

        public ObservableCollection<Client> FilteredProducts { get => filteredClients; set { filteredClients = value; OnPropertyChange(nameof(FilteredProducts)); } }

        public List<string> ListType { get; set; }
        public List<SortItem> ListSort { get; set; }

        public void LoadType()
        {
            ListType = new List<string>
            {
                "Все типы",
                "М",
                "Ж"
            };
        }
        public void LoadSort()
        {
            ListSort = new List<SortItem>()
            {
               new SortItem("FirstName","Фамилия")
            };
        }
        public void LoadProducts()
        {
            var request = new RestRequest("/api/ClientList", Method.GET);
            var response = UserServices.Instance.restClient.ExecuteAsync(request);
            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Clients = new ObservableCollection<Client>(JsonConvert.DeserializeObject<List<Client>>(response.Result.Content));
            }
        }

        public void InitializadeAll()
        {

            selectType = ListType[0];

            selectSort = ListSort[0];

            searchText = string.Empty;

            CurrentPage = 0;
        }

        public int MaxPages
        {
            get => Convert.ToInt32(Math.Ceiling((float)Clients
                .Where(p => p.FirstName
                .Contains(SearchText.ToLower()))
                .Where(p => SelectType.Equals("Все типы") ? p.Sex.Contains("") : p.Sex.Equals(SelectType)).Count() / (float)maxElemOnPage));
        }

        public string DisplayPage { get => $"{CurrentPage + 1}/{MaxPages}"; }

        private void FilteredList(string search, string filter, string sort = "FirstName", bool orderByDescening = false)
        {
            if (orderByDescening)
            {
                FilteredProducts = new ObservableCollection<Client>(
                    Clients.OrderByDescending(p => p.GetPropetry(sort))
                    .Where(p => p.FirstName.ToLower().Contains(search.ToLower()))
                    .Where(p => filter == "Все типы" ? p.Sex.Contains("") : p.Sex.Equals(filter))
                    .Skip(CurrentPage * maxElemOnPage).Take(maxElemOnPage));
            }
            else
            {
                FilteredProducts = new ObservableCollection<Client>(
                    Clients.OrderBy(p => p.GetPropetry(sort))
                    .Where(p => p.FirstName.ToLower().Contains(search.ToLower()))
                    .Where(p => filter == "Все типы" ? p.Sex.Contains("") : p.Sex.Equals(filter))
                    .Skip(CurrentPage * maxElemOnPage).Take(maxElemOnPage));
            }
            OnPropertyChange(nameof(DisplayPage));
        }




        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            OrderByDescening = true;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            OrderByDescening = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPage > 0)
                CurrentPage--;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (CurrentPage + 1 < MaxPages)
                CurrentPage++;
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            var add = new AddAndRedactClient();
            add.ShowDialog();
            if (add.DialogResult == true)
            {


                MessageBox.Show($"Клиент успешно добавлен!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadProducts();
                FilteredList(SearchText, SelectType, SelectSort.Property, OrderByDescening);
            }
            else
            {
                LoadProducts();
                FilteredList(SearchText, SelectType, SelectSort.Property, OrderByDescening);
            }
        }



        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (SelectClient != null)
            {
                var redact = new AddAndRedactClient(SelectClient);
                redact.ShowDialog();
                if (redact.DialogResult == true)
                {
                    MessageBox.Show($"Клиент успешно отредактирован!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadProducts();
                    FilteredList(SearchText, SelectType, SelectSort.Property, OrderByDescening);


                }
                else
                {
                    LoadProducts();
                    FilteredList(SearchText, SelectType, SelectSort.Property, OrderByDescening);
                }
            }
            else
            {
                MessageBox.Show($"Выберите клиента", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }


        #region OnPropertyChange
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChange([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            }
        }
        #endregion



        private void RedactClient_Click(object sender, RoutedEventArgs e)
        {
            if (SelectClient != null)
            {
                var redact = new AddAndRedactClient(SelectClient);
                redact.ShowDialog();
                if (redact.DialogResult == true)
                {
                    MessageBox.Show($"Клиент успешно отредактирован!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadProducts();
                    FilteredList(SearchText, SelectType, SelectSort.Property, OrderByDescening);


                }
                else
                {
                    LoadProducts();
                    FilteredList(SearchText, SelectType, SelectSort.Property, OrderByDescening);
                }
            }
            else
            {
                MessageBox.Show($"Выберите клиента", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }
    }
}
