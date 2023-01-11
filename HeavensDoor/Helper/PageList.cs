using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HeavensDoor.Helper
{
    public class PageList
    {
        public PageList(string name,Page page,PackIconKind packIconKind)
        {
            NamePage = name;
            PageMenu = page;
            PackIconKind = packIconKind;
        }

        public string NamePage { get;set; }
        public Page PageMenu { get; set; }
        public PackIconKind PackIconKind { get; set; }
    }
}
