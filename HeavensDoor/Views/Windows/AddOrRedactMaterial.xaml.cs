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
    /// Логика взаимодействия для AddOrRedactMaterial.xaml
    /// </summary>
    public partial class AddOrRedactMaterial : MaterialWindow, INotifyPropertyChanged
    {
        private string name;
        private string cost;
        private string amount;
        private bool isAdd = false;
        private string id;

        public Material CurrentMaterial { get; set; }

        public string Name1 { get => name; set { name = value; OnPropertyChanged(); } }
        public string Cost1 { get => cost; set { cost = value; OnPropertyChanged(); } }
        public string Amount1 { get => amount; set { amount = value; OnPropertyChanged(); } }

        public string Id { get => id; set => id = value; }

        public AddOrRedactMaterial()
        {
            AddForm();

            InitializeComponent();
            DelClient.Visibility = Visibility.Hidden;
            DataContext = this;
        }

        public AddOrRedactMaterial(Material products)
        {


            RefactorForm(products);

            InitializeComponent();
            DataContext = this;
            CountMaterialInForm.IsEnabled = false;

        }

        public void AddForm()
        {
            CurrentMaterial = new Material();
            id = string.Empty;
            Name1 = string.Empty;

            Amount1 = string.Empty;
            Cost1 = string.Empty;

            isAdd = true;
        }

        public void RefactorForm(Material products)
        {
            CurrentMaterial = products;

            Name1 = CurrentMaterial.Name;
            Amount1 = CurrentMaterial.MaterialToStorage.AmountMaterialToStorage.ToString();
            Cost1 = CurrentMaterial.Cost.ToString();
        }



        public bool ValidateProduct()
        {
            if (!string.IsNullOrEmpty(Name1)
                && (Amount1.Length > 0)
                && (Cost1.Length > 0))
                return true;
            else return false;

        }

        private async void DelClient_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Удалить", "Оповещение", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                var request = new RestRequest($"/api/Material/{CurrentMaterial.Idmaterial}", Method.DELETE);
                var response = await UserServices.Instance.restClient.ExecuteAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show($"Материал успешно удален!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                    DialogResult = false;
                }

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

        private async void SaveMaterial_Click(object sender, RoutedEventArgs e)
        {
            
            if (CurrentMaterial != null)
            {
                CurrentMaterial.Name = Name1;
                CurrentMaterial.Cost = Convert.ToInt32(Math.Round(Convert.ToDouble(Cost1)));

                if (ValidateProduct())
                {
                    RestRequest request = null;

                    if (isAdd)
                    {
                        var mat = new MaterialToStorage()
                        {                          
                              AmountMaterialToStorage=Convert.ToInt32(Amount1)
                        };
                        CurrentMaterial.MaterialToStorage = mat;
                        request = new RestRequest($"/api/Material/", Method.POST);
                    }
                    else
                    {
                        CurrentMaterial.MaterialToStorage.AmountMaterialToStorage = Convert.ToInt32(Amount1);
                        request = new RestRequest($"/api/Material/{CurrentMaterial.Idmaterial}", Method.PUT);
                    }

                    request.AddJsonBody(CurrentMaterial);
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

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
