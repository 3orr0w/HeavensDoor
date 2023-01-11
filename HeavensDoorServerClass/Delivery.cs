
using System;
using System.Collections.Generic;


namespace HeavensDoorServerClass
{
    public partial class Delivery
    {
        public Delivery()
        {
            MaterialInDeliveries = new HashSet<MaterialInDelivery>();
        }

        public int Iddelivey { get; set; }
        public DateTime? DateDelivery { get; set; }
        public int? Idstaff { get; set; }

        public virtual ICollection<MaterialInDelivery> MaterialInDeliveries { get; set; }
    }
}
