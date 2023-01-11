using HeavensDoorClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavensDoor.Helper
{
    public class MaterialsStatistic
    {
        public MaterialsStatistic(string material, int materialCount, long ticks)
        {
            Material = material;
            MaterialCount = materialCount;
            Ticks = ticks;
        }

        public string Material { get; set; }
        public int MaterialCount { get; set; }
        public long Ticks { get; set; }


    }
}
