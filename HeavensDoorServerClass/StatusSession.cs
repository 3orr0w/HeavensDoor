using System;
using System.Collections.Generic;


namespace HeavensDoorServerClass
{
    public partial class StatusSession
    {
        public StatusSession()
        {
            Sessions = new HashSet<Session>();
        }

        public int Idstatus { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}
