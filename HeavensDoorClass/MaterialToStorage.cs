using System;
using System.Collections.Generic;



namespace HeavensDoorClass
{
    public partial class MaterialToStorage
    {
        public int Idmaterial { get; set; }
        public int AmountMaterialToStorage { get; set; }

        public virtual Material IdmaterialNavigation { get; set; }
    }
}
