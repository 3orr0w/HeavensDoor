using System;
using System.Collections.Generic;


namespace HeavensDoorServerClass
{
    public partial class Storage
    {
        public Storage()
        {
            MaterialToStorages = new HashSet<MaterialToStorage>();
        }

        public int Idstorage { get; set; }
        public string NameStorage { get; set; }
        public int? Amount { get; set; }

        public virtual ICollection<MaterialToStorage> MaterialToStorages { get; set; }
    }
}
