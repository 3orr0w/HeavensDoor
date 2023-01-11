using System;
using System.Collections.Generic;



namespace HeavensDoorClass
{
    public partial class Client:Base
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
        public string FIO => FirstName + " " + MiddleName + " " + LastName;

    }
}
