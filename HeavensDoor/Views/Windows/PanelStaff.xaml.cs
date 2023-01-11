using HeavensDoor.Helper;

using HeavensDoor.UserService;
using HeavensDoorClass;
using MaterialDesignExtensions.Controls;
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

namespace HeavensDoor.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для StaffAutorization.xaml
    /// </summary>
    public partial class StaffAutorization : MaterialWindow, INotifyPropertyChanged
    {
        private ObservableCollection<Session> filteredSessions;
        private SortItem selectSort;
        private Session selectSession;
        private Procedure selectProcedre;
        private string selectType;
        private int currentPage;
        private int maxElemOnPage = 10;
        private string search;
        private bool orderByDescening;

        public StaffAutorization()
        {
           

            LoadProducts();
            LoadSort();
            LoadType();
            InitializadeAll();

            InitializeComponent();
            DataContext = this;
            UserServices.Instance.HubConnections.On("UpdateAdd", () =>
            {
                LoadProducts();
                FilteredList(Search, SelectType, SelectSort.Property, OrderByDescening);
            });
        }

        public ObservableCollection<Session> Sessions { get; set; }
        public SortItem SelectSort { get => selectSort; set { selectSort = value; OnPropertyChange(nameof(SelectSort)); FilteredList(Search, SelectType, SelectSort.Property, OrderByDescening); } }
        public Session SelectSession { get => selectSession; set { selectSession = value; OnPropertyChange(); } }
        public string SelectType { get => selectType; set { selectType = value; OnPropertyChange(nameof(SelectType)); FilteredList(Search, SelectType, SelectSort.Property, OrderByDescening); } }
        public int CurrentPage { get => currentPage; set { currentPage = value; FilteredList(Search, SelectType, SelectSort.Property, OrderByDescening); } }
        public string Search { get => search; set { search = value; OnPropertyChange(nameof(Search)); FilteredList(Search, SelectType, SelectSort.Property, OrderByDescening); } }
        public bool OrderByDescening { get => orderByDescening; set { orderByDescening = value; OnPropertyChange(nameof(OrderByDescening)); FilteredList(Search, SelectType, SelectSort.Property, OrderByDescening); } }

        public ObservableCollection<Session> FilteredSessions { get => filteredSessions; set { filteredSessions = value; OnPropertyChange(nameof(FilteredSessions)); } }

        public List<string> ListType { get; set; }
        public List<SortItem> ListSortSession { get; set; }


        public void LoadType()
        {
            ListType = new List<string>
            {
                "Все статусы",
                "Ожидание",
                "Завершен",
                "Отменен",
                "Не пришел"

            };
        }

        public void LoadSort()
        {
            ListSortSession = new List<SortItem>()
            {
               new SortItem("FIOClient","Клиент"),
               new SortItem("FIOStaff","Сотрудник"),
               new SortItem("NameProcedures","Процедура"),
               new SortItem("PriceProcedures","Цена процедуры"),
               new SortItem("DateTime","Дата проведения"),
               new SortItem("DateOrder","Дата заказа")
            };
        }

        public void LoadProducts()
        {
            var request = new RestRequest("/api/Session", Method.GET);
            var response = UserServices.Instance.restClient.ExecuteAsync(request);
            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Sessions = new ObservableCollection<Session>(JsonConvert.DeserializeObject<List<Session>>(response.Result.Content).Where(p => p.Idstaff == UserServices.Instance.Account.Idstaff));
               
            }
        }

        public void InitializadeAll()
        {

            selectType = ListType[0];

            selectSort = ListSortSession[0];

            search = string.Empty;

            CurrentPage = 0;
        }

        public int MaxPages
        {
            get => Convert.ToInt32(Math.Ceiling((float)Sessions
                 .Where(p => p.FIOClient
                 .Contains(Search.ToLower()))
                 .Where(p => SelectType.Equals("Все статусы") ? p.StatusSession.Contains("") : p.StatusSession.Equals(SelectType)).Count() / (float)maxElemOnPage));
        }

        public string DisplayPage { get => $"{CurrentPage + 1}/{MaxPages}"; }
        public Procedure SelectProcedre { get => selectProcedre; set => selectProcedre = value; }

        private void FilteredList(string search, string filter, string sort = "FIOClient", bool orderByDescening = false)
        {
            if (orderByDescening)
            {
                FilteredSessions = new ObservableCollection<Session>(
                    Sessions.OrderByDescending(p => p.GetPropetry(sort))
                    .Where(p => p.FIOClient.Contains(search.ToLower()))
                    .Where(p => filter == "Все статусы" ? p.StatusSession.Contains("") : p.StatusSession.Equals(filter))
                    .Skip(CurrentPage * maxElemOnPage).Take(maxElemOnPage));
            }
            else
            {
                FilteredSessions = new ObservableCollection<Session>(
                    Sessions.OrderBy(p => p.GetPropetry(sort))
                    .Where(p => p.FIOClient.Contains(search.ToLower()))
                    .Where(p => filter == "Все статусы" ? p.StatusSession.Contains("") : p.StatusSession.Equals(filter))
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

        private void GoSession_Click(object sender, RoutedEventArgs e)
        {
            if (SelectSession != null)
            {
                if (SelectSession.Idstatus != 1)
                {
                    MessageBox.Show($"Сеанс уже был проведен", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else
                {
                    ConductSession form = new ConductSession(SelectSession);
                    form.ShowDialog();
                    if (form.DialogResult == true)
                    {
                        MessageBox.Show($"Сеанс проведен", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                
            }
            else
            {
                MessageBox.Show($"Выберите сеанс", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Autorization au = new Autorization();
            au.Show();
            this.Close();
        }


    }
}
