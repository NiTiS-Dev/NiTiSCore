using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.Core.Additions.NiTiSON
{
    public class NiTiSONToken
    {
        public string name;
        public object value;
        public NiTiSONToken(string name, object value)
        {
            this.name = name;
            this.value = value;
        }
    }
}
