using HeavensDoor.Helper;
using HeavensDoor.UserService;
using HeavensDoor.Views.Windows;
using HeavensDoorClass;
using Microsoft.AspNetCore.SignalR.Client;
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
    /// Логика взаимодействия для DeliveryList.xaml
    /// </summary>
    public partial class DeliveryList : Page, INotifyPropertyChanged
    {
        private ObservableCollection<Delivery> filteredClients;
        private SortItem selectSort;
        private Delivery selectDelivery;
        private string selectType;
        private int currentPage;
        private int maxElemOnPage = 15;
        private string searchText;
        private bool orderByDescening;
        private StatusDelivery statusDelivery;

        public DeliveryList()
        {
            LoadProducts();
            LoadSort();
            LoadType();
            InitializadeAll();
            InitializeComponent();
            DataContext = this;
            if (UserServices.Instance.Account.Idpost == 4)
            {
                GoDelivery.Visibility = Visibility.Collapsed;
            }
            else
            {
                GoDelivery.Visibility = Visibility.Visible;
            }

            UserServices.Instance.HubConnections.On("UpdateDel", () =>
            {
                LoadProducts();
                FilteredList(SearchText, SelectType, SelectSort.Property, OrderByDescening);
            });
        }

        public ObservableCollection<Delivery> Deliveries { get; set; }
        public StatusDelivery StatusDelivery { get => statusDelivery; set { statusDelivery = value; OnPropertyChange(); } }

        public SortItem SelectSort { get => selectSort; set { selectSort = value; OnPropertyChange(nameof(SelectSort)); FilteredList(SearchText, SelectType, SelectSort.Property, OrderByDescening); } }
        public Delivery SelectDelivery { get => selectDelivery; set { selectDelivery = value; OnPropertyChange(); } }
        public string SelectType { get => selectType; set { selectType = value; OnPropertyChange(nameof(SelectType)); FilteredList(SearchText, SelectType, SelectSort.Property, OrderByDescening); } }
        public int CurrentPage { get => currentPage; set { currentPage = value; FilteredList(SearchText, SelectType, SelectSort.Property, OrderByDescening); } }
        public string SearchText { get => searchText; set { searchText = value; OnPropertyChange(nameof(SearchText)); FilteredList(SearchText, SelectType, SelectSort.Property, OrderByDescening); } }
        public bool OrderByDescening { get => orderByDescening; set { orderByDescening = value; OnPropertyChange(nameof(OrderByDescening)); FilteredList(SearchText, SelectType, SelectSort.Property, OrderByDescening); } }

        public ObservableCollection<Delivery> FilteredProducts { get => filteredClients; set { filteredClients = value; OnPropertyChange(nameof(FilteredProducts)); } }
        public List<StatusDelivery> StatusDeliveryList { get; set; }

        public List<string> ListType { get; set; }
        public List<SortItem> ListSort { get; set; }

        public void LoadType()
        {
            ListType = new List<string>
            {
                "Все типы",
                "В пути",
                "Доставлен"
            };
        }
        public void LoadSort()
        {
            ListSort = new List<SortItem>()
            {
               new SortItem("DateOrder","Дата заказа"),
               new SortItem("FioStaff","ФИО сотрудника")
            };
        }
        public void LoadProducts()
        {
            var request = new RestRequest("/api/Delivery", Method.GET);
            var response = UserServices.Instance.restClient.ExecuteAsync(request);
            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Deliveries = new ObservableCollection<Delivery>(JsonConvert.DeserializeObject<List<Delivery>>(response.Result.Content));
            }
        }

        public void InitializadeAll()
        {

            selectType = ListType[0];

            selectSort = ListSort[0];

            searchText = string.Empty;

            CurrentPage = 0;

            RestRequest request1 = new RestRequest($"/api/StatusDelivery/", Method.GET);
            var response1 = UserServices.Instance.restClient.ExecuteAsync(request1);
            StatusDeliveryList = JsonConvert.DeserializeObject<List<StatusDelivery>>(response1.Result.Content);
            StatusDelivery = StatusDeliveryList[0];
        }

        public int MaxPages
        {
            get => Convert.ToInt32(Math.Ceiling((float)Deliveries
                .Where(p => p.FioStaff
                .Contains(SearchText.ToLower()))
                .Where(p => SelectType.Equals("Все типы") ? p.Status.Contains("") : p.Status.Equals(SelectType)).Count() / (float)maxElemOnPage));
        }

        public string DisplayPage { get => $"{CurrentPage + 1}/{MaxPages}"; }

        private void FilteredList(string search, string filter, string sort = "DateOrder", bool orderByDescening = false)
        {
            if (orderByDescening)
            {
                FilteredProducts = new ObservableCollection<Delivery>(
                    Deliveries.OrderByDescending(p => p.GetPropetry(sort))
                    .Where(p => p.FioStaff.ToLower().Contains(search.ToLower()))
                    .Where(p => filter == "Все типы" ? p.Status.Contains("") : p.Status.Equals(filter))
                    .Skip(CurrentPage * maxElemOnPage).Take(maxElemOnPage));
            }
            else
            {
                FilteredProducts = new ObservableCollection<Delivery>(
                    Deliveries.OrderBy(p => p.GetPropetry(sort))
                    .Where(p => p.FioStaff.ToLower().Contains(search.ToLower()))
                    .Where(p => filter == "Все типы" ? p.Status.Contains("") : p.Status.Equals(filter))
                    .Skip(CurrentPage * maxElemOnPage).Take(maxElemOnPage));
            }
            OnPropertyChange(nameof(DisplayPage));
        }



        private void AddDelivery_Click(object sender, RoutedEventArgs e)
        {
            var add = new CreateDelivery();
            add.ShowDialog();
            if (add.DialogResult == true)
            {
                MessageBox.Show($"Поставка оформлена!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadProducts();
                FilteredList(SearchText, SelectType, SelectSort.Property, OrderByDescening);
            }
            else
            {
                LoadProducts();
                FilteredList(SearchText, SelectType, SelectSort.Property, OrderByDescening);
            }
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



        private void RadioButton_Click_1(object sender, RoutedEventArgs e)
        {
            OrderByDescening = true;
        }

        private void RadioButton_Click_2(object sender, RoutedEventArgs e)
        {
            OrderByDescening = false;

        }

        private void GoDelivery_Click(object sender, RoutedEventArgs e)
        {
            if (SelectDelivery != null)
            {
                if (SelectDelivery.IdStatusDelivery == 2)
                {
                    var request = new RestRequest($"/api/Delivery/{SelectDelivery.Iddelivey}", Method.PUT);
                    request.AddJsonBody(SelectDelivery);
                    var response = UserServices.Instance.restClient.ExecuteAsync(request);
                    if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        MessageBox.Show("Поставка принята. Материалы добавлены на склад", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadProducts();
                        FilteredList(SearchText, SelectType, SelectSort.Property, OrderByDescening);
                    }
                }
               else MessageBox.Show("Данная поставка была доставлена", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Выберите поставку", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //if(UserServices.Instance.Account.Idpost==13)
            //{
                var request = new RestRequest($"/api/Delivery/{SelectDelivery.Iddelivey}", Method.PUT);
                request.AddJsonBody(SelectDelivery);
                var response = UserServices.Instance.restClient.ExecuteAsync(request);
                if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("Поставка принята. Материалы добавлены на склад", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadProducts();
                    FilteredList(SearchText, SelectType, SelectSort.Property, OrderByDescening);
                }
            //}
            //else
            //{
            //    MessageBox.Show("У этого пользователя недостаточно прав", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);

            //}

        }
    }
}
