using System;
using System.Collections.Generic;



namespace HeavensDoorClass
{
    public partial class staff:Base
    {
        public staff()
        {
            Deliveries = new HashSet<Delivery>();
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
        public string Sex { get; set; }
        public int IdstatusStaff { get; set; }

        public virtual Post IdpostNavigation { get; set; }
        public virtual StaffStatus IdstatusStaffNavigation { get; set; }
        public virtual Account Account { get; set; }
        public virtual ICollection<Delivery> Deliveries { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
        public string Fio => FirstName + " " + MiddleName + " " + LastName;
        public string PostStaff => IdpostNavigation?.Name;
        public string StatusStaff => IdstatusStaffNavigation?.Name;
    }
}
