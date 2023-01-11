using HeavensDoor.Helper;
using HeavensDoor.UserService;
using HeavensDoor.Views.Windows;
using HeavensDoorClass;
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

namespace HeavensDoor.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для MaterialList.xaml
    /// </summary>
    public partial class MaterialList : Page, INotifyPropertyChanged
    {
        private ObservableCollection<Material> filteredMaterial;
        private Material selectMaterial;
        private SortItem selectSort;
        private string searchText;
        private bool orderByDescening;
        private int maxElemOnPage = 15;
        private int currentPage;


        public MaterialList()
        {          
            LoadProducts();
            LoadSort();
            InitializadeAll();
            InitializeComponent();
            DataContext = this;
            FilteredList(SearchText, SelectSort.Property, OrderByDescening);
            UserServices.Instance.HubConnections.On("UpdateMaterials", () =>
            {
                LoadProducts();
                FilteredList(SearchText, SelectSort.Property, OrderByDescening);
            });
        }

        public ObservableCollection<Material> Materials { get; set; }
        public Material SelectMaterial { get => selectMaterial; set { selectMaterial = value; OnPropertyChange(); } }
        public string SearchText { get => searchText; set { searchText = value; OnPropertyChange(nameof(SearchText)); FilteredList(SearchText, SelectSort.Property, OrderByDescening); } }
        public SortItem SelectSort { get => selectSort; set { selectSort = value; OnPropertyChange(nameof(SelectSort)); FilteredList(SearchText, SelectSort.Property, OrderByDescening); } }
        public bool OrderByDescening { get => orderByDescening; set { orderByDescening = value; OnPropertyChange(nameof(OrderByDescening)); FilteredList(SearchText, SelectSort.Property, OrderByDescening); } }
        public int CurrentPage { get => currentPage; set { currentPage = value; FilteredList(SearchText, SelectSort.Property, OrderByDescening); } }

        public ObservableCollection<Material> FilteredMaterial { get => filteredMaterial; set { filteredMaterial = value; OnPropertyChange(nameof(FilteredMaterial)); } }
        public List<SortItem> ListSort { get; set; }

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
            SelectSort = ListSort[0];
        }

        public void LoadSort()
        {
            ListSort = new List<SortItem>()
            {
               new SortItem("Cost","Стоимость"),
               new SortItem("CountMaterial","Количество"),

            };
        }

        public int MaxPages
        {
            get => Convert.ToInt32(Math.Ceiling((float)Materials
                .Where(p => p.Name
                .Contains(SearchText.ToLower())).Count() / (float)maxElemOnPage));
        }

        public string DisplayPage { get => $"{CurrentPage + 1}/{MaxPages}"; }


        private void FilteredList(string search, string sort, bool isBool = false)
        {
            if (isBool)
            {
                FilteredMaterial = new ObservableCollection<Material>(
                    Materials.OrderByDescending(p => p.GetPropetry(sort)).Where(p => p.Name.ToLower().Contains(search.ToLower()))
                .Skip(CurrentPage * maxElemOnPage).Take(maxElemOnPage));
            }
            else
            {
                FilteredMaterial = new ObservableCollection<Material>(
                    Materials.OrderBy(p => p.GetPropetry(sort)).Where(p => p.Name.ToLower().Contains(search.ToLower()))
               .Skip(CurrentPage * maxElemOnPage).Take(maxElemOnPage));
            }
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
            var add = new AddOrRedactMaterial();
            add.ShowDialog();
            if (add.DialogResult == true)
            {

                MessageBox.Show($"Материал успешно сохранен!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadProducts();
                FilteredList(SearchText, SelectSort.Property, OrderByDescening);

            }
            else
            {
                LoadProducts();
                FilteredList(SearchText, SelectSort.Property, OrderByDescening);
            }
        }

        private void RedactMaterial_Click(object sender, RoutedEventArgs e)
        {
            if (SelectMaterial != null)
            {
                var redact = new AddOrRedactMaterial(SelectMaterial);
                redact.ShowDialog();
                if (redact.DialogResult == true)
                {
                    MessageBox.Show($"Материал успешно отредактирован!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadProducts();
                    FilteredList(SearchText, SelectSort.Property, OrderByDescening);
                }
                else
                {
                    LoadProducts();
                    FilteredList(SearchText, SelectSort.Property, OrderByDescening);
                }
            }
            else
            {
                MessageBox.Show($"Выберите материал", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            OrderByDescening = true;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            OrderByDescening = false;
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (SelectMaterial != null)
            {
                var redact = new AddOrRedactMaterial(SelectMaterial);
                redact.ShowDialog();
                if (redact.DialogResult == true)
                {
                    MessageBox.Show($"Материал успешно отредактирован!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadProducts();
                    FilteredList(SearchText, SelectSort.Property, OrderByDescening);
                }
                else
                {
                    LoadProducts();
                    FilteredList(SearchText, SelectSort.Property, OrderByDescening);
                }
            }
            else
            {
                MessageBox.Show($"Выберите материал", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }
    }
}
