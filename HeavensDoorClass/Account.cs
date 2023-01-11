using System;
using System.Collections.Generic;


namespace HeavensDoorClass
{
    public partial class Account
    {
        public int Idstaff { get; set; }
        public string LoginStaff { get; set; }
        public string PasswordStaff { get; set; }
        public int Idaccount { get; set; }

        public virtual staff IdstaffNavigation { get; set; }
    }
}
