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
    /// Логика взаимодействия для ProcedureSelectedList.xaml
    /// </summary>
    public partial class ProcedureSelectedList : MaterialWindow, INotifyPropertyChanged
    {
        private ObservableCollection<Procedure> filteredProcedure;
        private Procedure selectProcedure;
        private string searchText;
        public ProcedureSelectedList()
        {
            LoadProducts();
            InitializadeAll();
            InitializeComponent();
            DataContext = this;
            FilteredList(SearchText);
        }
        public ObservableCollection<Procedure> Procedures { get; set; }
        public Procedure SelectedProcedure { get => selectProcedure; set { selectProcedure = value; OnPropertyChange(); } }
        public string SearchText { get => searchText; set { searchText = value; OnPropertyChange(nameof(SearchText)); FilteredList(SearchText); } }

        public ObservableCollection<Procedure> FilteredProcedure { get => filteredProcedure; set { filteredProcedure = value; OnPropertyChange(nameof(FilteredProcedure)); } }

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
            var request = new RestRequest("/api/Procedure", Method.GET);
            var response = UserServices.Instance.restClient.ExecuteAsync(request);
            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Procedures = new ObservableCollection<Procedure>(JsonConvert.DeserializeObject<List<Procedure>>(response.Result.Content));
            }
        }

        public void InitializadeAll()
        {

            searchText = string.Empty;

        }
        private void FilteredList(string search)
        {

            FilteredProcedure = new ObservableCollection<Procedure>(Procedures.Where(p => p.Name.Contains(search.ToLower())));
        }

        private void SelectProcedure_Click(object sender, RoutedEventArgs e)
        {
            if (SelectProcedure != null)
            {
                this.DialogResult = true;
            }
            else MessageBox.Show("Выберите процедуру", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
