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
    /// Логика взаимодействия для StaffSelectedList.xaml
    /// </summary>
    public partial class StaffSelectedList : MaterialWindow, INotifyPropertyChanged
    {
        private ObservableCollection<staff> filteredStaff;
        private staff selectStaff;
        private string searchText;
        public StaffSelectedList()
        {
            LoadProducts();

            InitializadeAll();
            InitializeComponent();
            DataContext = this;
            FilteredList(SearchText);
        }
        public ObservableCollection<staff> Staffs { get; set; }
        public staff SelectStaff { get => selectStaff; set { selectStaff = value; OnPropertyChange(); } }
        public string SearchText { get => searchText; set { searchText = value; OnPropertyChange(nameof(SearchText)); FilteredList(SearchText); } }

        public ObservableCollection<staff> FilteredStaff { get => filteredStaff; set { filteredStaff = value; OnPropertyChange(nameof(FilteredStaff)); } }

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

        public void LoadProducts()
        {
            var request = new RestRequest("/api/Staff", Method.GET);
            var response = UserServices.Instance.restClient.ExecuteAsync(request);
            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Staffs = new ObservableCollection<staff>(JsonConvert.DeserializeObject<List<staff>>(response.Result.Content).Where(p=>p.Idpost==1 || p.Idpost==5).Where(P=>P.IdstatusStaff==1));
            }
        }

        public void InitializadeAll()
        {

            searchText = string.Empty;

        }

        private void FilteredList(string search)
        {

            FilteredStaff = new ObservableCollection<staff>(Staffs.Where(p => p.FirstName.Contains(search.ToLower())));
        }

        private void AddMaterial_Click(object sender, RoutedEventArgs e)
        {
            if (SelectStaff != null)
            {
                this.DialogResult = true;

            }
            else MessageBox.Show("Выберите сотрудника", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
