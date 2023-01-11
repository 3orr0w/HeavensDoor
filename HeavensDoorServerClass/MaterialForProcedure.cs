
using System;
using System.Collections.Generic;


namespace HeavensDoorServerClass
{
    public partial class MaterialForProcedure
    {
        public int Idprocedure { get; set; }
        public int Idmaterial { get; set; }
        public int AmountMaterialToProcedures { get; set; }

        public virtual Material IdmaterialNavigation { get; set; }
        public virtual Procedure IdprocedureNavigation { get; set; }
    }
}
