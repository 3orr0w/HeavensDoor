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
    /// Логика взаимодействия для StaffList.xaml
    /// </summary>
    public partial class StaffList : Page, INotifyPropertyChanged
    {
        private ObservableCollection<staff> filteredStaff;
        private SortItem selectSort;
        private staff selectStaff;
        private string selectType;
        private int currentPage;
        private int maxElemOnPage = 10;
        private string search;
        private bool orderByDescening;
        public StaffList()
        {
            LoadProducts();
            LoadSort();
            LoadType();
            InitializadeAll();

            InitializeComponent();

        }
        public ObservableCollection<staff> Staffs { get; set; }
        public SortItem SelectSort { get => selectSort; set { selectSort = value; OnPropertyChange(nameof(SelectSort)); FilteredList(Search, SelectType, SelectSort.Property, OrderByDescening); } }
        public staff SelectStaff { get => selectStaff; set { selectStaff = value; OnPropertyChange(); } }
        public string SelectType { get => selectType; set { selectType = value; OnPropertyChange(nameof(SelectType)); FilteredList(Search, SelectType, SelectSort.Property, OrderByDescening); } }
        public int CurrentPage { get => currentPage; set { currentPage = value; FilteredList(Search, SelectType, SelectSort.Property, OrderByDescening); } }
        public string Search { get => search; set { search = value; OnPropertyChange(nameof(Search)); FilteredList(Search, SelectType, SelectSort.Property, OrderByDescening); } }
        public bool OrderByDescening { get => orderByDescening; set { orderByDescening = value; OnPropertyChange(nameof(OrderByDescening)); FilteredList(Search, SelectType, SelectSort.Property, OrderByDescening); } }

        public ObservableCollection<staff> FilteredStaff { get => filteredStaff; set { filteredStaff = value; OnPropertyChange(nameof(FilteredStaff)); } }

        public List<string> ListType { get; set; }
        public List<SortItem> ListSortStaff { get; set; }

        public void LoadType()
        {
            ListType = new List<string>
            {
                "Все должности",
                "Массажист",
                "Уборщик",
                "Администратор",
                "Специалист по маникюру",
                "Директор",
                "Зам. директора по коммерции"



            };
        }
        public void LoadSort()
        {
            ListSortStaff = new List<SortItem>()
            {
               new SortItem("Fio","Клиент")

            };
        }

        public void LoadProducts()
        {
            var request = new RestRequest("/api/Staff", Method.GET);
            var response = UserServices.Instance.restClient.ExecuteAsync(request);
            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Staffs = new ObservableCollection<staff>(JsonConvert.DeserializeObject<List<staff>>(response.Result.Content).Where(p=>p.Idstaff!=UserServices.Instance.Account.Idstaff));
                DataContext = this;
            }
        }

        public void InitializadeAll()
        {

            selectType = ListType[0];

            selectSort = ListSortStaff[0];

            search = string.Empty;

            CurrentPage = 0;
        }

        public int MaxPages
        {
            get => Convert.ToInt32(Math.Ceiling((float)Staffs
                .Where(p => p.Fio
                .Contains(Search.ToLower()))
                .Where(p => SelectType.Equals("Все должности") ? p.PostStaff.Contains("") : p.PostStaff.Equals(SelectType)).Count() / (float)maxElemOnPage));
        }

        public string DisplayPage { get => $"{CurrentPage + 1}/{MaxPages}"; }

        private void FilteredList(string search, string filter, string sort = "Fio", bool orderByDescening = false)
        {
            if (orderByDescening)
            {
                FilteredStaff = new ObservableCollection<staff>(
                    Staffs.OrderByDescending(p => p.GetPropetry(sort))
                    .Where(p => p.Fio.Contains(search.ToLower()))
                    .Where(p => filter == "Все должности" ? p.PostStaff.Contains("") : p.PostStaff.Equals(filter))
                    .Skip(CurrentPage * maxElemOnPage).Take(maxElemOnPage));
            }
            else
            {
                FilteredStaff = new ObservableCollection<staff>(
                    Staffs.OrderBy(p => p.GetPropetry(sort))
                    .Where(p => p.Fio.Contains(search.ToLower()))
                    .Where(p => filter == "Все должности" ? p.PostStaff.Contains("") : p.PostStaff.Equals(filter))
                    .Skip(CurrentPage * maxElemOnPage).Take(maxElemOnPage));
            }
            OnPropertyChange(nameof(DisplayPage));
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

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            OrderByDescening = false;
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            OrderByDescening = true;
        }

        private void AddStaff_Click(object sender, RoutedEventArgs e)
        {
            var add = new AddOrRedactStaff();
            add.ShowDialog();
            if (add.DialogResult == true)
            {


                MessageBox.Show($"Клиент успешно добавлен!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadProducts();
                FilteredList(Search, SelectType, SelectSort.Property, OrderByDescening);
            }
            else
            {
                LoadProducts();
                FilteredList(Search, SelectType, SelectSort.Property, OrderByDescening);
            }
        }

        private void RedactStaff_Click(object sender, RoutedEventArgs e)
        {
            if (SelectStaff != null)
            {
                var add = new AddOrRedactStaff(SelectStaff);
                add.ShowDialog();
                if (add.DialogResult == true)
                {


                    MessageBox.Show($"Клиент успешно изменен!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadProducts();
                    FilteredList(Search, SelectType, SelectSort.Property, OrderByDescening);
                }
                else
                {
                    LoadProducts();
                    FilteredList(Search, SelectType, SelectSort.Property, OrderByDescening);
                }
            }
            else
            {
                MessageBox.Show($"Выберите клиента", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var add = new AddOrRedactStaff(SelectStaff);
            add.ShowDialog();
            if (add.DialogResult == true)
            {


                MessageBox.Show($"Клиент успешно изменен!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadProducts();
                FilteredList(Search, SelectType, SelectSort.Property, OrderByDescening);
            }
            else
            {
                LoadProducts();
                FilteredList(Search, SelectType, SelectSort.Property, OrderByDescening);
            }
        }
    }
}
