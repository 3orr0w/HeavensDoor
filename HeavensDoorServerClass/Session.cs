
using System;
using System.Collections.Generic;


namespace HeavensDoorServerClass
{
    public partial class Session
    {
        public int Idsession { get; set; }
        public int Idprocedures { get; set; }
        public int Idstaff { get; set; }
        public int Idclient { get; set; }
        public DateTime? DateTime { get; set; }
        public int? Idstatus { get; set; }
        public DateTime? DateOrder { get; set; }

        public virtual Client IdclientNavigation { get; set; }
        public virtual Procedure IdproceduresNavigation { get; set; }
        public virtual staff IdstaffNavigation { get; set; }
        public virtual StatusSession IdstatusNavigation { get; set; }
    }
}
