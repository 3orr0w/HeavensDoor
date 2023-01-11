using HeavensDoorClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HeavensDoor.Helper
{
    public class MaterialForProceduresInSession
    {
        private int count;
        
        public event EventHandler OnCountChanged;
        public MaterialForProceduresInSession(Material name, int count)
        {
            NameM = name;
            Count = count;
        }

        public Material NameM { get; set; }
        public int Count
        {
            get => count;
            set
            {
                count = value;
                OnCountChanged?.Invoke(this, new EventArgs());
            }
        }
    }
}
