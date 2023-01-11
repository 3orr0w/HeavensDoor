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
    /// Логика взаимодействия для ProcedureList.xaml
    /// </summary>
    public partial class ProcedureList : Page, INotifyPropertyChanged
    {
        private ObservableCollection<Procedure> filteredProcedures;
        private Procedure selectProcedure;
        private SortItem selectSort;

        private string search;
        private bool orderByDescening;
        private int maxElemOnPage = 15;
        private int currentPage;
        public ProcedureList()
        {
           
            LoadProducts();
            LoadSort();
            InitializadeAll();

            InitializeComponent();
            DataContext = this;


        }

        public ObservableCollection<Procedure> Procedures { get; set; }
        public Procedure SelectProcedure { get => selectProcedure; set { selectProcedure = value; OnPropertyChange(); } }
        public bool OrderByDescening { get => orderByDescening; set { orderByDescening = value; OnPropertyChange(nameof(OrderByDescening)); FilteredList(Search, SelectSort.Property, OrderByDescening); } }
        public int CurrentPage { get => currentPage; set { currentPage = value; FilteredList(Search, SelectSort.Property, OrderByDescening); } }
        public SortItem SelectSort { get => selectSort; set { selectSort = value; OnPropertyChange(nameof(SelectSort)); FilteredList(Search, SelectSort.Property, OrderByDescening); } }

        public List<SortItem> ListSort { get; set; }
        public string Search { get => search; set { search = value; OnPropertyChange(nameof(Search)); FilteredList(Search, SelectSort.Property, OrderByDescening); } }

        public ObservableCollection<Procedure> FilteredProcedures { get => filteredProcedures; set { filteredProcedures = value; OnPropertyChange(); } }
        public void LoadProducts()
        {
            var request = new RestRequest("/api/Procedure", Method.GET);
            var response = UserServices.Instance.restClient.ExecuteAsync(request);
            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Procedures = new ObservableCollection<Procedure>(JsonConvert.DeserializeObject<List<Procedure>>(response.Result.Content));
            }
        }

        public void InitializadeAll()
        {

            search = string.Empty;
            SelectSort = ListSort[0];

            CurrentPage = 0;
        }

        public void LoadSort()
        {
            ListSort = new List<SortItem>()
            {
               new SortItem("Price","Стоимость"),
               new SortItem("Time","Время"),

            };
        }

        public int MaxPages
        {
            get => Convert.ToInt32(Math.Ceiling((float)Procedures
                .Where(p => p.Name
                .Contains(Search.ToLower()))
                .Count() / (float)maxElemOnPage));
        }

        public string DisplayPage { get => $"{CurrentPage + 1}/{MaxPages}"; }

        private void FilteredList(string search, string sort, bool isBool = false)
        {
            if (isBool)
            {
                FilteredProcedures = new ObservableCollection<Procedure>(
                    Procedures.OrderByDescending(p => p.GetPropetry(sort)).Where(p => p.Name.ToLower().Contains(search.ToLower()))
                .Skip(CurrentPage * maxElemOnPage).Take(maxElemOnPage));
            }
            else
            {
                FilteredProcedures = new ObservableCollection<Procedure>(
                    Procedures.OrderBy(p => p.GetPropetry(sort)).Where(p => p.Name.ToLower().Contains(search.ToLower()))
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


        private void AddClient_Click_1(object sender, RoutedEventArgs e)
        {
            var add = new ProcedureInfo();
            add.ShowDialog();
            if (add.DialogResult == true)
            {

                MessageBox.Show($"Запись успешно добавлена!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadProducts();
                FilteredList(Search, SelectSort.Property, OrderByDescening);

            }
            else
            {
                LoadProducts();
                FilteredList(Search, SelectSort.Property, OrderByDescening);
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

        private void RedactSession_Click(object sender, RoutedEventArgs e)
        {
            if (SelectProcedure != null)
            {
                var redact = new ProcedureInfo(SelectProcedure);
                redact.ShowDialog();
                if (redact.DialogResult == true)
                {
                    MessageBox.Show($"Процедура успешно отредактирована!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadProducts();
                    FilteredList(Search, SelectSort.Property, OrderByDescening);
                }
                else
                {
                    LoadProducts();
                    FilteredList(Search, SelectSort.Property, OrderByDescening);
                }
            }
            else
            {
                MessageBox.Show($"Выберите материал", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var redact = new ProcedureInfo(SelectProcedure);
            redact.ShowDialog();
            if (redact.DialogResult == true)
            {
                MessageBox.Show($"Материал успешно отредактирован!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadProducts();
                FilteredList(Search, SelectSort.Property, OrderByDescening);
            }
            else
            {
                LoadProducts();
                FilteredList(Search, SelectSort.Property, OrderByDescening);
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            OrderByDescening = true;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            OrderByDescening = false;

        }
    }
}
