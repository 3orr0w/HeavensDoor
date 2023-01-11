using HeavensDoor.Helper;
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
    /// Логика взаимодействия для ConductSession.xaml
    /// </summary>
    public partial class ConductSession : MaterialWindow, INotifyPropertyChanged
    {
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

        private DateTime dateTime;
        private string id;
        private string currentStaff;
        private string currentProcedure;
        private string currentClient;
        private MaterialForProceduresInSession selected;
        public Client SelectedClient { get; set; }
        public staff SelectedStaff { get; set; }
        public Procedure SelectedProcedure { get; set; }

        public Session CurrentSession { get; set; }
        public List<StatusSession> StatusSessions { get; set; }
        public StatusSession SelectedStatus { get; set; }
        public Material SelectedMaterial { get; set; }
        public MaterialForProceduresInSession SelectedMaterialForCoduct { get => selected; set { selected = value; OnPropertyChanged(); } }


        public DateTime DateTimes { get => dateTime; set { dateTime = value; OnPropertyChanged(); } }
        public string Id { get => id; set => id = value; }
        public string CurrentStaff { get => currentStaff; set { currentStaff = value; OnPropertyChanged(); } }
        public string CurrentProcedure { get => currentProcedure; set { currentProcedure = value; OnPropertyChanged(); } }
        public string CurrentClient { get => currentClient; set { currentClient = value; OnPropertyChanged(); } }
        public ObservableCollection<Material> Materials { get; set; }
        public ObservableCollection<MaterialForProceduresInSession> MaterialForConduct { get; set; }


        public ConductSession(Session session)
        {

            RefactorForm(session);
            LoadMaterial();
            InitializeComponent();
            DataContext = this;

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

            MaterialForConduct = new ObservableCollection<MaterialForProceduresInSession>();
        }

        public void LoadStatus()
        {
            RestRequest request = new RestRequest($"/api/StatusSession/", Method.GET);
            var response = UserServices.Instance.restClient.ExecuteAsync(request);
            StatusSessions = JsonConvert.DeserializeObject<List<StatusSession>>(response.Result.Content);
        }

        public void LoadMaterial()
        {
            Materials = new ObservableCollection<Material>(SelectedProcedure.MaterialForProcedures.Select(p => p.IdmaterialNavigation));
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedMaterial != null)
            {
                if (MaterialForConduct.Any(p => p.NameM.Idmaterial == SelectedMaterial.Idmaterial) == false)
                {
                    MaterialForConduct.Add(new MaterialForProceduresInSession(SelectedMaterial, 0));
                }
                else MessageBox.Show("Материал для сеанса уже добавлен", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else MessageBox.Show("Выберите материал для добавления", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void BackSelect_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedMaterialForCoduct != null)
            {
                MaterialForConduct.Remove(SelectedMaterialForCoduct);
            }
            else MessageBox.Show("Выберите материал для удаления", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private async void SaveSession1_Click(object sender, RoutedEventArgs e)
        {
            //if (SelectedStatus.Idstatus == 2)
            //{
            CurrentSession.IdproceduresNavigation.MaterialForProcedures = new List<MaterialForProcedure>(MaterialForConduct.Select(p => new MaterialForProcedure
            {
                Idmaterial = p.NameM.Idmaterial,
                AmountMaterialToProcedures = p.Count,
                IdmaterialNavigation = p.NameM,
            }));


            RestRequest request = new RestRequest($"/api/Session/MaterialInSession", Method.POST);
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
            //}   
            //else
            //{
            //    CurrentSession.Idstaff = SelectedStaff.Idstaff;
            //    CurrentSession.Idclient = SelectedClient.Idclient;
            //    CurrentSession.Idprocedures = SelectedProcedure.Idprocedure;
            //    CurrentSession.DateTime = null;
            //    CurrentSession.DateOrder = DateTimes;
            //    CurrentSession.Idstatus=SelectedStatus.Idstatus;
            //    RestRequest request = new RestRequest($"/api/Session", Method.PUT);
            //    request.AddJsonBody(CurrentSession);
            //    var response = await UserServices.Instance.restClient.ExecuteAsync(request);
            //    if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //    {
            //        this.DialogResult = true;
            //        MessageBox.Show("Запись сохранена", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
            //    }
            //}
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
