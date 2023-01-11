using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace HeavensDoorClass
{
    public partial class StaffStatus
    {
        public StaffStatus()
        {
            staff = new HashSet<staff>();
        }

        public int IdstaffStatus { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<staff> staff { get; set; }
    }
}
