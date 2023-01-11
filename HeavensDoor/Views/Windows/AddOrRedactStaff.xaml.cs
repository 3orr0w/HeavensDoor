using HeavensDoor.UserService;
using HeavensDoorClass;
using MaterialDesignExtensions.Controls;
using Newtonsoft.Json;
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
    /// Логика взаимодействия для AddOrRedactStaff.xaml
    /// </summary>
    public partial class AddOrRedactStaff : MaterialWindow, INotifyPropertyChanged
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private string sexStaff;
        private string telephone;
        private string emailStaff;
        private string adress;
        private string login;
        private string password;
        private Post post;
        private StaffStatus status;
        private string id;
        private bool isAdd = false;

        public AddOrRedactStaff()
        {
            AddForm();
            InitializeComponent();
            DataContext = this;
            isAdd = true;
            DelStaff.Visibility = Visibility.Collapsed;
        }

        public AddOrRedactStaff(staff staff)
        {
            RefactorForm(staff);
            InitializeComponent();
            DataContext = this;

        }

        public staff CurrentStaff { get; set; }
        public List<string> Types { get; set; }
        public List<StaffStatus> StatusStaffList { get; set; }
        public List<Post> PostStaffList { get; set; }
        public Account Account { get; set; }
        public string FirstName { get => firstName; set { firstName = value; OnPropertyChanged(); } }
        public string MiddleName { get => middleName; set { middleName = value; OnPropertyChanged(); } }
        public string LastName { get => lastName; set { lastName = value; OnPropertyChanged(); } }
        public string Sex { get => sexStaff; set { sexStaff = value; OnPropertyChanged(); } }
        public string Telephone { get => telephone; set { telephone = value; OnPropertyChanged(); } }
        public string Email { get => emailStaff; set { emailStaff = value; OnPropertyChanged(); } }

        public string Id { get => id; set => id = value; }
        public string Adress { get => adress; set { adress = value; OnPropertyChanged(); } }
        public Post Post { get => post; set { post = value; } }
        public StaffStatus Status { get => status; set { status = value; } }

        public string Login { get => login; set { login = value; OnPropertyChanged(); } }
        public string Password { get => password; set { password = value; OnPropertyChanged(); } }

        public void LoadList()
        {
            Types = new List<string>
            {
                "М",
                "Ж"
            };

            RestRequest request1 = new RestRequest($"/api/Status/", Method.GET);
            var response1 = UserServices.Instance.restClient.ExecuteAsync(request1);
            StatusStaffList = JsonConvert.DeserializeObject<List<StaffStatus>>(response1.Result.Content);

            RestRequest request = new RestRequest($"/api/Post/", Method.GET);
            var response = UserServices.Instance.restClient.ExecuteAsync(request);
            PostStaffList = JsonConvert.DeserializeObject<List<Post>>(response.Result.Content);
        }

        public void AddForm()
        {
            CurrentStaff = new staff();
            LoadList();
            id = string.Empty;
            FirstName = string.Empty;
            MiddleName = string.Empty;
            LastName = string.Empty;
            Telephone = string.Empty;
            Email = string.Empty;
            Adress = string.Empty;
            Login = String.Empty;
            Password = String.Empty;
            Post = PostStaffList[0];
            Status = StatusStaffList[0];
            isAdd = true;
            Sex = Types[0];

        }

        public void RefactorForm(staff staff)
        {
            CurrentStaff = staff;
            LoadList();
            Id = CurrentStaff.Idstaff.ToString();
            FirstName = CurrentStaff.FirstName;
            MiddleName = CurrentStaff.MiddleName;
            LastName = CurrentStaff.LastName;
            Sex = Types.FirstOrDefault(p => p.Equals(CurrentStaff.Sex));
            Telephone = CurrentStaff.Telephone.ToString();
            Email = CurrentStaff.Email.ToString();
            Adress = CurrentStaff.Adress;
            Post = PostStaffList.FirstOrDefault(p => p.Idpost == CurrentStaff.Idpost);
            Status = StatusStaffList.FirstOrDefault(p => p.IdstaffStatus == CurrentStaff.IdstatusStaff);
            Login = CurrentStaff.Account.LoginStaff;
            Password = CurrentStaff.Account.PasswordStaff;
        }



        public bool ValidateProduct()
        {

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(Email);
            if (!string.IsNullOrEmpty(FirstName)
                && !string.IsNullOrEmpty(LastName)
                && !string.IsNullOrEmpty(Sex)
                && !string.IsNullOrEmpty(Telephone)
                && (Telephone.Length == 11)
                && match.Success
                && !string.IsNullOrEmpty(MiddleName) && !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password))
                return true;
            else return false;

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

        private async void SaveSTAFF_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentStaff != null)
            {

                CurrentStaff.FirstName = FirstName;
                CurrentStaff.MiddleName = MiddleName;
                CurrentStaff.LastName = LastName;
                CurrentStaff.Sex = Sex;
                CurrentStaff.Telephone = Convert.ToDouble(Telephone);
                CurrentStaff.Email = Email;
                CurrentStaff.Adress = Adress;
                CurrentStaff.IdstatusStaff = Status.IdstaffStatus;
                CurrentStaff.Idpost = Post.Idpost;

                if (ValidateProduct())
                {
                    RestRequest request = null;

                    if (isAdd)
                    {
                        var acc = new Account()
                        {
                            LoginStaff = Login,
                            PasswordStaff = Password,
                        };
                        CurrentStaff.Account = acc;
                        request = new RestRequest($"/api/Staff/", Method.POST);

                    }
                    else
                    {
                        CurrentStaff.Account.LoginStaff = Login;
                        CurrentStaff.Account.PasswordStaff = Password;
                        request = new RestRequest($"/api/Staff/{CurrentStaff.Idstaff}", Method.PUT);
                    }

                    request.AddJsonBody(CurrentStaff);
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
                else MessageBox.Show("Валидация не пройдена", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void DelStaff_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Удалить", "Оповещение", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                var request = new RestRequest($"/api/Staff/{CurrentStaff.Idstaff}", Method.DELETE);
                var response = await UserServices.Instance.restClient.ExecuteAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show($"Сотрудник успешно удален!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                    DialogResult = false;
                }
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }

}
