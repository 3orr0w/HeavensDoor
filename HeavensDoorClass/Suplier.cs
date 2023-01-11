using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace HeavensDoorClass
{
    public partial class Suplier
    {
        public Suplier()
        {
            Deliveries = new HashSet<Delivery>();
        }

        public int Idsuplier { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }

        [JsonIgnore]
        public virtual ICollection<Delivery> Deliveries { get; set; }
    }
}
