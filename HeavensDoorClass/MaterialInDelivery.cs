using System;
using System.Collections.Generic;



namespace HeavensDoorClass
{
    public partial class MaterialInDelivery
    {
        public int Idmaterial { get; set; }
        public int Iddelivery { get; set; }
        public int AmountMaterialInDelivery { get; set; }

        public virtual Delivery IddeliveryNavigation { get; set; }
        public virtual Material IdmaterialNavigation { get; set; }
    }
}
