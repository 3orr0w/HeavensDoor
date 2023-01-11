
using HeavensDoor.UserService;
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

namespace HeavensDoor.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddSession.xaml
    /// </summary>
    public partial class AddSession : MaterialWindow, INotifyPropertyChanged
    {
        private DateTime dateTime;
        private bool isAdd = false;
        private string id;
        private string currentStaff;
        private string currentProcedure;
        private string currentClient;
        public Client SelectedClient { get; set; }
        public staff SelectedStaff { get; set; }
        public Procedure SelectedProcedure { get; set; }
        public Session CurrentSession { get; set; }
        public List<StatusSession> StatusSessions { get; set; }
        public StatusSession SelectedStatus { get; set; }


        public DateTime DateTimes { get => dateTime; set => dateTime = value; }
        public string Id { get => id; set => id = value; }
        public string CurrentStaff { get => currentStaff; set { currentStaff = value; OnPropertyChanged(); } }
        public string CurrentProcedure { get => currentProcedure; set { currentProcedure = value; OnPropertyChanged(); } }
        public string CurrentClient { get => currentClient; set { currentClient = value; OnPropertyChanged(); } }


        public AddSession()
        {
            AddForm();
            InitializeComponent();
            DataContext = this;
            isAdd = true;
            CanselSession.Visibility = Visibility.Collapsed;
            SelectClient.IsEnabled = false;
            SelectProcedure.IsEnabled = false;
        }

        public AddSession(Session session)
        {
            RefactorForm(session);
            InitializeComponent();
            DataContext = this;
            if (session.Idstatus != 1)
            {
                SaveSession.IsEnabled = false;
            }
        }

        public void AddForm()
        {
            CurrentSession = new Session();
            LoadStatus();
            id = string.Empty;

            SelectedStatus = StatusSessions[0];
            DateTimes = DateTime.Now;
        }

        public void RefactorForm(Session session)
        {
            CurrentSession = session;
            LoadStatus();
            Id = CurrentSession.Idsession.ToString();
            SelectedStatus = StatusSessions.FirstOrDefault(p => p.Idstatus == CurrentSession.Idstatus);
            CurrentClient = CurrentSession.FIOClient;
            CurrentProcedure = CurrentSession.NameProcedures;
            CurrentStaff = CurrentSession.FIOStaff;
            DateTimes = CurrentSession.DateOrder;
            SelectedClient = CurrentSession.IdclientNavigation;
            SelectedStaff = CurrentSession.IdstaffNavigation;
            SelectedProcedure = CurrentSession.IdproceduresNavigation;

        }

        public void LoadStatus()
        {
            RestRequest request = new RestRequest($"/api/StatusSession/", Method.GET);
            var response = UserServices.Instance.restClient.ExecuteAsync(request);
            StatusSessions = JsonConvert.DeserializeObject<List<StatusSession>>(response.Result.Content);
        }

        #region OnPropertyChange
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            }
        }
        #endregion

        private async void SaveSession_Click(object sender, RoutedEventArgs e)
        {
            if(DateTimes<DateTime.Now.AddDays(1))
            {
                MessageBox.Show("Дата сеанса не может быть назначена в текущий день", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                if (SelectedClient != null)
                {
                    if (SelectedProcedure != null)
                    {
                        if (SelectedStaff != null)
                        {
                            CurrentSession.Idclient = SelectedClient.Idclient;
                            CurrentSession.Idstaff = SelectedStaff.Idstaff;
                            CurrentSession.Idprocedures = SelectedProcedure.Idprocedure;
                            CurrentSession.Idstatus = SelectedStatus.Idstatus;
                            CurrentSession.DateOrder = DateTimes;


                            RestRequest request = null;

                            if (isAdd)
                            {
                                CurrentSession.DateTime = null;
                                CurrentSession.Idstatus = StatusSessions[0].Idstatus;
                                request = new RestRequest($"/api/Session/", Method.POST);
                            }
                            else
                            {
                                request = new RestRequest($"/api/Session/{CurrentSession.Idsession}", Method.PUT);
                            }

                            request.AddJsonBody(CurrentSession);
                            var response = await UserServices.Instance.restClient.ExecuteAsync(request);
                            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                this.DialogResult = true;
                                MessageBox.Show("Запись сохранена", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                            {
                                MessageBox.Show($"{JsonConvert.DeserializeObject<string>(response.Content)}", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else MessageBox.Show("Выберите сотрудника", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else MessageBox.Show("Выберите процедуру", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else MessageBox.Show("Выберите клиента", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
          

        }


        private void SelectStaff_Click(object sender, RoutedEventArgs e)
        {
            var stfa = new StaffSelectedList();
            stfa.ShowDialog();
            if (stfa.DialogResult == true)
            {
                SelectedStaff = stfa.SelectStaff;
                CurrentStaff = SelectedStaff.Fio;
                SelectClient.IsEnabled = true;
            }
        }

        private void SelectClient_Click(object sender, RoutedEventArgs e)
        {
            var stfa = new ClientSelectedList();
            stfa.ShowDialog();
            if (stfa.DialogResult == true)
            {
                SelectedClient = stfa.SelectedClient;
                CurrentClient = SelectedClient.FIO;
                SelectProcedure.IsEnabled = true;
            }
        }

        private void SelectProcedure_Click(object sender, RoutedEventArgs e)
        {

            var stfa = new ProcedureSelectedList();
            stfa.ShowDialog();
            if (stfa.DialogResult == true)
            {
                SelectedProcedure = stfa.SelectedProcedure;
                CurrentProcedure = SelectedProcedure.Name;

            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private async void CanselSession_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Удалить", "Оповещение", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                var request = new RestRequest($"/api/Session/{CurrentSession.Idsession}", Method.DELETE);
                var response = await UserServices.Instance.restClient.ExecuteAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show($"Сеанс успешно удален!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                    DialogResult = false;
                }

            }
        }
    }
}