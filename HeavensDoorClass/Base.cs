using System;
using System.Collections.Generic;
using System.Text;

namespace HeavensDoorClass
{
    public class Base
    {
        public object GetPropetry(string prop)
        {
            if (!string.IsNullOrEmpty(prop))
            {
                return this.GetType().GetProperty(prop).GetValue(this);
            }
            return null;
        }
    }
}
