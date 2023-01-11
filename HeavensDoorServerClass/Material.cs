
using System;
using System.Collections.Generic;


namespace HeavensDoorServerClass
{
    public partial class Material
    {
        public Material()
        {
            MaterialForProcedures = new HashSet<MaterialForProcedure>();
            MaterialInDeliveries = new HashSet<MaterialInDelivery>();
            MaterialToStorages = new HashSet<MaterialToStorage>();
        }

        public int Idmaterial { get; set; }
        public string Name { get; set; }
        public int AmountMaterial { get; set; }

        public virtual ICollection<MaterialForProcedure> MaterialForProcedures { get; set; }
        public virtual ICollection<MaterialInDelivery> MaterialInDeliveries { get; set; }
        public virtual ICollection<MaterialToStorage> MaterialToStorages { get; set; }
    }
}
