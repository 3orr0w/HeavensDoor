
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
    /// Логика взаимодействия для ProcedureInfo.xaml
    /// </summary>
    public partial class ProcedureInfo : MaterialWindow, INotifyPropertyChanged
    {
        private string id;
        private string time;
        private string description;
        private string price;
        private string image;
        private string name;
        private bool isAdd = false;

        public Procedure CurrentProcedure { get; set; }
        public Material SelectedMaterial { get; set; }
        public List<Post> PostList { get; set; }
        public Post SelectedPost { get; set; }


        public ProcedureInfo()
        {

            AddForm();
            LoadMaterial();
            InitializeComponent();
            DataContext = this;
            DelClient.Visibility = Visibility.Collapsed;
        }

        public ProcedureInfo(Procedure products)
        {

            RefactorForm(products);
            LoadMaterial();
            InitializeComponent();
            DataContext = this;
        }

        public string Id { get => id; set { id = value; } }
        public string Name1 { get => name; set => name = value; }
        public string Time { get => time; set { time = value; } }
        public string Description { get => description; set { description = value; } }
        public string Price { get => price; set { price = value; } }
        public string Image { get => image; set { image = value; } }

        public ObservableCollection<Material> Materials { get; set; }

        public void LoadPost()
        {
            RestRequest request = new RestRequest($"/api/Post/", Method.GET);
            var response = UserServices.Instance.restClient.ExecuteAsync(request);
            PostList = JsonConvert.DeserializeObject<List<Post>>(response.Result.Content).Where(p=>p.Idpost==1 || p.Idpost==5).ToList();
        }

        public void AddForm()
        {
            CurrentProcedure = new Procedure();
            LoadPost();
            Id = string.Empty;
            Name1 = string.Empty;
            Description = string.Empty;
            Time = string.Empty;
            Image = string.Empty;
            Price = string.Empty;
            isAdd = true;
        }

        public void RefactorForm(Procedure products)
        {
            CurrentProcedure = products;
            LoadPost();
            Id = CurrentProcedure.Idprocedure.ToString();
            Name1 = CurrentProcedure.Name;
            Description = CurrentProcedure.Description;
            Time = CurrentProcedure.Time.ToString();
            Image = null;
            Price = CurrentProcedure.Price.ToString();
            SelectedPost = PostList[0];
        }

        public void LoadMaterial()
        {
            Materials = new ObservableCollection<Material>(CurrentProcedure.MaterialForProcedures.Select(p => p.IdmaterialNavigation));
        }

        public bool ValidateProduct()
        {
            if (!string.IsNullOrEmpty(Name1)
                && (Time.Length > 0)
                && (Price.Length > 0) && !string.IsNullOrEmpty(Description))
                return true;
            else return false;

        }

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChange([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            }
        }

        #endregion

        private async void SaveProcedure_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentProcedure != null)
            {

                CurrentProcedure.Name = Name1;
                CurrentProcedure.Price = Convert.ToInt32(Math.Round(Convert.ToDouble(Price)));
                CurrentProcedure.Time = Convert.ToInt32(Time);
                CurrentProcedure.Description = Description;
                

                var list = new List<MaterialForProcedure>();
                foreach (var item in Materials)
                {
                    list.Add(new MaterialForProcedure
                    {
                        AmountMaterialToProcedures = 0,
                        Idmaterial = item.Idmaterial
                    });
                }
                CurrentProcedure.MaterialForProcedures = list;



                if (ValidateProduct())
                {
                    RestRequest request = null;

                    if (isAdd)
                    {
                       
                        CurrentProcedure.ProcedureToPosts = new List<ProcedureToPost>();
                        CurrentProcedure.ProcedureToPosts.Add(new ProcedureToPost
                        {
                             Idpost = SelectedPost.Idpost,
                        });

                        request = new RestRequest($"/api/Procedure/", Method.POST);
                    }
                    else
                    {
                        request = new RestRequest($"/api/Procedure/{CurrentProcedure.Idprocedure}", Method.PUT);
                    }

                    request.AddJsonBody(CurrentProcedure);
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

        private void SelectMaterial_Click(object sender, RoutedEventArgs e)
        {
            var add = new MaterialSelectedList();
            add.ShowDialog();
            if (add.DialogResult == true)
            {
                if (Materials.Any(p => p.Idmaterial == add.SelectMaterial.Idmaterial)==false)
                {
                    Materials.Add(add.SelectMaterial);
                }
                else MessageBox.Show("Материал для процедуры уже добавлен", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void DelMaterial_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedMaterial != null)
            {
                var material = SelectedMaterial;
                Materials.Remove(material);
            }
            else MessageBox.Show("Выберите материал", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private async void DelClient_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Удалить", "Оповещение", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                var request = new RestRequest($"/api/Procedure/{CurrentProcedure.Idprocedure}", Method.DELETE);
                var response = await UserServices.Instance.restClient.ExecuteAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show($"Процедура успешно удалена!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
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
