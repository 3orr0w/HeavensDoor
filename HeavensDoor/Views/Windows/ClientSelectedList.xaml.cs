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
    /// Логика взаимодействия для ClientSelectedList.xaml
    /// </summary>
    public partial class ClientSelectedList : MaterialWindow, INotifyPropertyChanged
    {
        private ObservableCollection<Client> filteredClient;
        private Client selectClient;
        private string searchText;
        public ClientSelectedList()
        {
            LoadProducts();

            InitializadeAll();
            InitializeComponent();
            DataContext = this;
            FilteredList(SearchText);
        }
        public ObservableCollection<Client> Clients { get; set; }
        public Client SelectedClient { get => selectClient; set { selectClient = value; OnPropertyChange(); } }
        public string SearchText { get => searchText; set { searchText = value; OnPropertyChange(nameof(SearchText)); FilteredList(SearchText); } }

        public ObservableCollection<Client> FilteredClient { get => filteredClient; set { filteredClient = value; OnPropertyChange(nameof(FilteredClient)); } }

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
            var request = new RestRequest("/api/ClientList", Method.GET);
            var response = UserServices.Instance.restClient.ExecuteAsync(request);
            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Clients = new ObservableCollection<Client>(JsonConvert.DeserializeObject<List<Client>>(response.Result.Content));
            }
        }

        public void InitializadeAll()
        {

            searchText = string.Empty;

        }
        private void FilteredList(string search)
        {

            FilteredClient = new ObservableCollection<Client>(Clients.Where(p => p.FirstName.Contains(search.ToLower())));
        }

        private void SelectClient_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
