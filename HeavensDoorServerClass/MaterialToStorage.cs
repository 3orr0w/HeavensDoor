
using System;
using System.Collections.Generic;


namespace HeavensDoorServerClass
{
    public partial class MaterialToStorage
    {
        public int Idstorage { get; set; }
        public int Idmaterial { get; set; }
        public int? AmountMaterialToStorage { get; set; }

        public virtual Material IdmaterialNavigation { get; set; }
        public virtual Storage IdstorageNavigation { get; set; }
    }
}
