using HeavensDoor.UserService;
using HeavensDoorClass;
using MaterialDesignExtensions.Controls;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : MaterialWindow, INotifyPropertyChanged
    {
        private string login;
        private string passwords;
        public string Login { get => login; set { login = value; OnPropertyChanged(); } }
        public string Passwords { get => passwords; set { passwords = value; OnPropertyChanged(); } }

        public Autorization()
        {
            InitializeComponent();
            DataContext = this;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            exit.IsEnabled = false;
            var request = new RestRequest("/api/Autorization", Method.POST);
            request.AddJsonBody(new { login = Login, password = Passwords });
            var response = await UserServices.Instance.restClient.ExecuteAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                UserServices.Instance.HubConnections = new HubConnectionBuilder().WithUrl(@"http://localhost:5000/Services").Build();
                UserServices.Instance.HubConnections.StartAsync();
                var result = JsonConvert.DeserializeObject<staff>(response.Content);
                UserServices.Instance.Account = result;
                if (result.Idpost == 4)
                {
                    PanelAdministrator adm = new PanelAdministrator();
                    this.Close();
                    adm.Show();
                }
                else if (result.Idpost == 1)
                {
                    StaffAutorization adm = new StaffAutorization();
                    this.Close();
                    adm.Show();
                }
                else if (result.Idpost == 13)
                {
                    PanelStaffInStorage adm = new PanelStaffInStorage();
                    this.Close();
                    adm.Show();
                }
                else if (result.Idpost == 8)
                {
                    PanelMenager adm = new PanelMenager();
                    this.Close();
                    adm.Show();
                }
                MessageBox.Show($"Привет, {result.Fio}", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Логин или пароль введен не верно", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Error);
                exit.IsEnabled = true;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
