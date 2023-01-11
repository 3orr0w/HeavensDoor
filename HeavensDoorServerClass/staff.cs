using System;
using System.Collections.Generic;


namespace HeavensDoorServerClass
{
    public partial class staff
    {
        public staff()
        {
            Accounts = new HashSet<Account>();
            Sessions = new HashSet<Session>();
        }

        public int Idstaff { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Idpost { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public double Telephone { get; set; }
        public string Photo { get; set; }
        public string Sex { get; set; }

        public virtual Post IdpostNavigation { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
