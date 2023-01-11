using Newtonsoft.Json;
using System;
using System.Collections.Generic;



namespace HeavensDoorClass
{
    public partial class StatusSession
    {
        public StatusSession()
        {
            Sessions = new HashSet<Session>();
        }

        public int Idstatus { get; set; }
        public string Status { get; set; }

        [JsonIgnore]
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
