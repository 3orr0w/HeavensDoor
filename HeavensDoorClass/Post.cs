using System;
using System.Collections.Generic;



namespace HeavensDoorClass
{
    public partial class Post
    {
        public Post()
        {
            ProcedureToPosts = new HashSet<ProcedureToPost>();
            staff = new HashSet<staff>();
        }

        public int Idpost { get; set; }
        public string Name { get; set; }
        public string WorkSchedule { get; set; }
        public int Salary { get; set; }

        public virtual ICollection<ProcedureToPost> ProcedureToPosts { get; set; }
        public virtual ICollection<staff> staff { get; set; }
    }
}
