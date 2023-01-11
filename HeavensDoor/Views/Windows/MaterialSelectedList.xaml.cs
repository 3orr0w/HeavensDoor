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
  
    public partial class MaterialSelectedList : MaterialWindow, INotifyPropertyChanged
    {
        private ObservableCollection<Material> filteredMaterial;
        private Material selectMaterial;

        private string searchText;
        public MaterialSelectedList()
        {
            LoadProducts();

            InitializadeAll();
            InitializeComponent();
            DataContext = this;
            FilteredList(SearchText);
        }
        public ObservableCollection<Material> Materials { get; set; }
        public Material SelectMaterial { get => selectMaterial; set { selectMaterial = value; OnPropertyChange(); } }
        public string SearchText { get => searchText; set { searchText = value; OnPropertyChange(nameof(SearchText)); FilteredList(SearchText); } }

        public ObservableCollection<Material> FilteredMaterial { get => filteredMaterial; set { filteredMaterial = value; OnPropertyChange(nameof(FilteredMaterial)); } }



        public void LoadProducts()
        {
            var request = new RestRequest("/api/Material", Method.GET);
            var response = UserServices.Instance.restClient.ExecuteAsync(request);
            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Materials = new ObservableCollection<Material>(JsonConvert.DeserializeObject<List<Material>>(response.Result.Content));
            }
        }

        public void InitializadeAll()
        {

            searchText = string.Empty;

        }
        private void FilteredList(string search)
        {

            FilteredMaterial = new ObservableCollection<Material>(Materials.Where(p => p.Name.Contains(search.ToLower())));
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

        private void AddMaterial_Click(object sender, RoutedEventArgs e)
        {
            if (SelectMaterial != null)
            {
                this.DialogResult = true;
            }
            else MessageBox.Show("Выберите материал", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);

           
        }

        private void BackMaterial_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
