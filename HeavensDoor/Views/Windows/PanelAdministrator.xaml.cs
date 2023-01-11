using HeavensDoor.Helper;
using HeavensDoor.Views.Pages;
using HeavensDoor.Views.Windows;
using MaterialDesignExtensions.Controls;
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
    /// Логика взаимодействия для PanelAdministrator.xaml
    /// </summary>
    public partial class PanelAdministrator : MaterialWindow,INotifyPropertyChanged
    {
        #region fields
        public List<PageList> MainMenu { get; set; }
        public List<PageList> FooterMenu { get; set; }
        private PageList selectedMenuItem;
        private PageList selectedOptionalItem;


        public PageList SelectedMenuItem { get => selectedMenuItem; set { selectedMenuItem = value;OnPropertyChange(); NextPageMainMenu(); } }
        public PageList SelectedOptionalItem { get => selectedOptionalItem; set { selectedOptionalItem = value; OnPropertyChange(); NextPageOptionalMenu(); } }

        #endregion

        #region constructor
        public PanelAdministrator()
        {
            InitializeComponent();
            MainMenu = new List<PageList>
            {
                new PageList("Список клиентов", new ClientList(),MaterialDesignThemes.Wpf.PackIconKind.Users),              
                new PageList("Список процедур", new ProcedureList(),MaterialDesignThemes.Wpf.PackIconKind.Hand),
                new PageList("Список сотрудников", new StaffList(),MaterialDesignThemes.Wpf.PackIconKind.ManMan),
                new PageList("Список сеансов", new SessionsList(),MaterialDesignThemes.Wpf.PackIconKind.Abacus),
                new PageList("Список материалов", new MaterialList(),MaterialDesignThemes.Wpf.PackIconKind.Material),
                new PageList("Список поставок", new DeliveryList(),MaterialDesignThemes.Wpf.PackIconKind.DeliveryDining)

            };

            FooterMenu = new List<PageList>
            {              
                new PageList("Выход", null,MaterialDesignThemes.Wpf.PackIconKind.ExitToApp)
            };          
            SelectedMenuItem = MainMenu.FirstOrDefault();
            DataContext = this;         
        }

        #endregion

        #region methods

        public void NextPageMainMenu()
        {
            if (SelectedMenuItem != null)
            {
                pageContainer.Navigate(SelectedMenuItem.PageMenu);
                this.Title = SelectedMenuItem.NamePage;

            }
        }

        public void NextPageOptionalMenu()
        {
            if (SelectedOptionalItem != null)
            {
                if (SelectedOptionalItem.NamePage == "Выход")
                {
                    Autorization au = new Autorization();
                    au.Show();
                    this.Close();
                }
                else
                {
                    pageContainer.Navigate(SelectedOptionalItem.PageMenu);                    
                }
            }
        }
        #endregion

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
    }
}
