using Newtonsoft.Json;
using System;
using System.Collections.Generic;



namespace HeavensDoorClass
{
    public partial class StatusDelivery
    {
        public StatusDelivery()
        {
            Deliveries = new HashSet<Delivery>();
        }

        public int Idstatus { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<Delivery> Deliveries { get; set; }
    }
}
