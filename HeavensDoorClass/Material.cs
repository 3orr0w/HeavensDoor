using System;
using System.Collections.Generic;



namespace HeavensDoorClass
{
    public partial class Material:Base
    {
        public Material()
        {
            MaterialForProcedures = new HashSet<MaterialForProcedure>();
            MaterialInDeliveries = new HashSet<MaterialInDelivery>();
        }

        public int Idmaterial { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }

        public virtual MaterialToStorage MaterialToStorage { get; set; }
        public virtual ICollection<MaterialForProcedure> MaterialForProcedures { get; set; }
        public virtual ICollection<MaterialInDelivery> MaterialInDeliveries { get; set; }
        public int? CountMaterial =>MaterialToStorage?.AmountMaterialToStorage;
    }
}
