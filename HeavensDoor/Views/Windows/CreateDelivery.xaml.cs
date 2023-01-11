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
    /// Логика взаимодействия для CreateDelivery.xaml
    /// </summary>
    public partial class CreateDelivery : MaterialWindow, INotifyPropertyChanged
    {
        private int price;
        private string articul;
        private StatusDelivery statusDelivery;
        private Suplier suplier;
        private ObservableCollection<MaterialForProceduresInSession> selected;

        public Delivery CurrentDelivery { get; set; }
        public MaterialForProceduresInSession SelectedMaterial { get; set; }


        public List<Suplier> SuplierList { get; set; }
        public List<StatusDelivery> StatusDeliveryList { get; set; }
        public string Articul { get => articul; set { articul = value; OnPropertyChanged(); } }
        public StatusDelivery StatusDelivery { get => statusDelivery; set { statusDelivery = value; OnPropertyChanged(); } }
        public Suplier Suplier { get => suplier; set { suplier = value; OnPropertyChanged(); } }
        public ObservableCollection<MaterialForProceduresInSession> SelectedMaterialForDelivery { get => selected; set { selected = value; OnPropertyChanged(); } }

        public int Price { get => price; set { price = value; OnPropertyChanged(); } }


        public CreateDelivery()
        {
            LoadDelivery();
            LoadList();
            InitializeComponent();
            DataContext = this;
            Articul = GenerateArticul(8);
        }



        public void LoadList()
        {
            RestRequest request1 = new RestRequest($"/api/StatusDelivery/", Method.GET);
            var response1 = UserServices.Instance.restClient.ExecuteAsync(request1);
            StatusDeliveryList = JsonConvert.DeserializeObject<List<StatusDelivery>>(response1.Result.Content);
            StatusDelivery = StatusDeliveryList[1];

            RestRequest request = new RestRequest($"/api/Suplier/", Method.GET);
            var response = UserServices.Instance.restClient.ExecuteAsync(request);
            SuplierList = JsonConvert.DeserializeObject<List<Suplier>>(response.Result.Content);
            Suplier = SuplierList[0];
            SelectedMaterialForDelivery = new ObservableCollection<MaterialForProceduresInSession>();
        }

        public void LoadDelivery()
        {
            CurrentDelivery = new Delivery();
        }



        public string GenerateArticul(int artticulLenght)
        {
            string articul = string.Empty;
            Random random = new Random();
            for (int i = 0; i < artticulLenght; i++)
            {
                switch (random.Next(1, 3))
                {
                    case 1:
                        articul += (char)random.Next('A', 'Z');
                        break;
                    case 2:
                        articul += (char)random.Next('0', '9');
                        break;
                }

            }
            return articul;
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

        private void SelectMaterial_Click(object sender, RoutedEventArgs e)
        {
            var add = new MaterialSelectedList();
            add.ShowDialog();
            if (add.DialogResult == true)
            {
                if (SelectedMaterialForDelivery.Any(p => p.NameM.Name == add.SelectMaterial.Name) == false)
                {
                    var new1 = new MaterialForProceduresInSession(add.SelectMaterial, 1);
                    new1.OnCountChanged += Update;
                    SelectedMaterialForDelivery.Add(new1);
                    Price += add.SelectMaterial.Cost * 1;
                }
                else
                {
                    MessageBox.Show("Материал для поставки уже добавлен", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
        }

        private void Update(object sender, EventArgs e)
        {
            Price = SelectedMaterialForDelivery.Sum(P => P.NameM.Cost * P.Count);
        }

        private void DelMaterial_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedMaterial != null)
            {
                var material = SelectedMaterial;
                SelectedMaterialForDelivery.Remove(material);
                Price -= material.Count * material.NameM.Cost;
            }
            else MessageBox.Show("Выберите материал", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private async void SaveDelivery_Click(object sender, RoutedEventArgs e)
        {
            CurrentDelivery.Idstaff = UserServices.Instance.Account.Idstaff;
            CurrentDelivery.IdStatusDelivery = StatusDelivery.Idstatus;
            CurrentDelivery.Articul = Articul;
            CurrentDelivery.DateOrder = DateTime.Now;
            CurrentDelivery.Idsupplier = Suplier.Idsuplier;
            CurrentDelivery.DateDelivery = null;

            CurrentDelivery.MaterialInDeliveries = new List<MaterialInDelivery>(SelectedMaterialForDelivery.Select(p => new MaterialInDelivery
            {
                Idmaterial = p.NameM.Idmaterial,
                AmountMaterialInDelivery = p.Count,

            }));

            RestRequest request = new RestRequest($"/api/Delivery", Method.POST);
            request.AddJsonBody(CurrentDelivery);
            var response = await UserServices.Instance.restClient.ExecuteAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                this.DialogResult = true;
                MessageBox.Show("Запись сохранена", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void DelClient_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
