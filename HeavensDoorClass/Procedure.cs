using System;
using System.Collections.Generic;


namespace HeavensDoorClass
{
    public partial class Procedure:Base
    {
        public Procedure()
        {
            MaterialForProcedures = new HashSet<MaterialForProcedure>();
            ProcedureToPosts = new HashSet<ProcedureToPost>();
            Sessions = new HashSet<Session>();
        }

        public int Idprocedure { get; set; }
        public int Time { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }

        public virtual ICollection<MaterialForProcedure> MaterialForProcedures { get; set; }
        public virtual ICollection<ProcedureToPost> ProcedureToPosts { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
