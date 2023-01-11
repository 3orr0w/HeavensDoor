
using System;
using System.Collections.Generic;


namespace HeavensDoorServerClass
{
    public partial class Client
    {
        public Client()
        {
            Sessions = new HashSet<Session>();
        }

        public int Idclient { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Sex { get; set; }
        public double Telephone { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}
