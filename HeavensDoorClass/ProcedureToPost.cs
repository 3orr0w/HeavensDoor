using System;
using System.Collections.Generic;



namespace HeavensDoorClass
{
    public partial class ProcedureToPost
    {
        public int Idpost { get; set; }
        public int Idprocedure { get; set; }

        public virtual Post IdpostNavigation { get; set; }
        public virtual Procedure IdprocedureNavigation { get; set; }
    }
}
