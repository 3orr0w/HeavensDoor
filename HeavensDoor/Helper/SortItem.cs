using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavensDoor.Helper
{
   public class SortItem
    {
        public string Property { get; set; }
        public string Title { get; set; }

        public SortItem(string property, string title)
        {
            Property = property;
            Title = title;
        }
    }
}
