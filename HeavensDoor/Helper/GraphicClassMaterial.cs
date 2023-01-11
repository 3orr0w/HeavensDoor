using HeavensDoorClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavensDoor.Helper
{
    public class GraphicClassMaterial
    {
        public GraphicClassMaterial(Procedure procedure, int count, double cost)
        {
            Procedure = procedure;
            Count = count;
            Cost = cost;
        }

        public Procedure Procedure { get; set; }
        public int Count { get; set; }
        public double Cost { get; set; }  
    }
}
