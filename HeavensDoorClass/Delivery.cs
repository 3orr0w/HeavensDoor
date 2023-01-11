using System;
using System.Collections.Generic;


namespace HeavensDoorClass
{
    public partial class Delivery:Base
    {
        public Delivery()
        {
            MaterialInDeliveries = new HashSet<MaterialInDelivery>();
        }

        public int Iddelivey { get; set; }
        public DateTime? DateDelivery { get; set; }
        public int Idstaff { get; set; }
        public DateTime DateOrder { get; set; }
        public int IdStatusDelivery { get; set; }
        public int Idsupplier { get; set; }
        public string Articul { get; set; }

        public virtual StatusDelivery IdStatusDeliveryNavigation { get; set; }
        public virtual staff IdstaffNavigation { get; set; }
        public virtual Suplier IdsupplierNavigation { get; set; }
        public virtual ICollection<MaterialInDelivery> MaterialInDeliveries { get; set; }
        public string FioStaff => IdstaffNavigation?.Fio;
        public string Status => IdStatusDeliveryNavigation?.Name;
        public string Supplier => IdsupplierNavigation?.Name;

    }
}
