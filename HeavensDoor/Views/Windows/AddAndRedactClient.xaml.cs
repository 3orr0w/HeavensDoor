
using HeavensDoor.UserService;
using HeavensDoorClass;
using MaterialDesignExtensions.Controls;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AddAndRedactClient.xaml
    /// </summary>
    public partial class AddAndRedactClient : MaterialWindow, INotifyPropertyChanged
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private string sexClient;
        private string telephoneClient;
        private string emailClient;
        private string id;
        private bool isAdd = false;

        public Client CurrentClient { get; set; }
        public List<string> Types { get; set; }
        public string FirstName { get => firstName; set { firstName = value; OnPropertyChanged(); } }
        public string MiddleName { get => middleName; set { middleName = value; OnPropertyChanged(); } }
        public string LastName { get => lastName; set { lastName = value; OnPropertyChanged(); } }
        public string SexClient { get => sexClient; set { sexClient = value; OnPropertyChanged(); } }
        public string TelephoneClient { get => telephoneClient; set { telephoneClient = value; OnPropertyChanged(); } }
        public string EmailClient { get => emailClient; set { emailClient = value; OnPropertyChanged(); } }

        public string Id { get => id; set => id = value; }

        public AddAndRedactClient()
        {
            DataContext = this;

            AddForm();

            InitializeComponent();
            DelClient.Visibility = Visibility.Hidden;

        }

        public AddAndRedactClient(Client products)
        {
            DataContext = this;

            RefactorForm(products);

            InitializeComponent();

        }
        public void AddForm()
        {
            CurrentClient = new Client();
            id = string.Empty;
            FirstName = string.Empty;
            Types = new List<string>
            {
                 "М",
                "Ж"
            };
            MiddleName = string.Empty;
            LastName = string.Empty;
            SexClient = Types[0];
            TelephoneClient = string.Empty;
           
            EmailClient = string.Empty;
            isAdd = true;
        }

        public void RefactorForm(Client products)
        {
            CurrentClient = products;
            Id = CurrentClient.Idclient.ToString();
            FirstName = CurrentClient.FirstName;
            Types = new List<string>
            {

                "М",
                "Ж"
            };
            MiddleName = CurrentClient.MiddleName;
            LastName = CurrentClient.LastName;
            SexClient = Types.FirstOrDefault(p => p.Equals(CurrentClient.Sex));
            TelephoneClient = CurrentClient.Telephone.ToString();
            EmailClient = CurrentClient.Email.ToString();

        }



        public bool ValidateProduct()
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(EmailClient);
            if (!string.IsNullOrEmpty(FirstName)
                && !string.IsNullOrEmpty(LastName)
                && !string.IsNullOrEmpty(SexClient)
                && (TelephoneClient.Length == 11 || TelephoneClient.Length == 7)
                && match.Success
                && !string.IsNullOrEmpty(MiddleName))
                return true;
            else return false;

        }


        private async void DelClient_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Удалить", "Оповещение", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                var request = new RestRequest($"/api/ClientList/{CurrentClient.Idclient}", Method.DELETE);
                var response = await UserServices.Instance.restClient.ExecuteAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show($"Клиент успешно удален!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                    DialogResult = false;
                }

            }
        }


        private async void SaveClient_Click(object sender, RoutedEventArgs e)
        {

            if (CurrentClient != null)
            {

                CurrentClient.FirstName = FirstName;
                CurrentClient.MiddleName = MiddleName;
                CurrentClient.LastName = LastName;
                CurrentClient.Sex = SexClient;
                CurrentClient.Telephone = Convert.ToDouble(TelephoneClient);
                CurrentClient.Email = EmailClient;
                if (ValidateProduct())
                {
                    RestRequest request = null;

                    if (isAdd)
                    {
                        request = new RestRequest($"/api/ClientList/", Method.POST);
                    }
                    else
                    {
                        request = new RestRequest($"/api/ClientList/{CurrentClient.Idclient}", Method.PUT);
                    }

                    request.AddJsonBody(CurrentClient);
                    var response = await UserServices.Instance.restClient.ExecuteAsync(request);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        this.DialogResult = true;
                        MessageBox.Show("Запись сохранена", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else MessageBox.Show("Валидация не пройдена", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult=false;
        }
    }
}
