using NiTiS.Core.Types;
using NiTiS.Core.Collections;
using System.Collections.Generic;
using System.Collections;

namespace NiTiS.Core.Additions.NiTiSON
{
    public class NiTiSON : IEnumerable
    {
        private Dictionary<string, object> dictonary = new Dictionary<string, object>();
        public void Put(string name, object element)
        {
            dictonary[name] = element;
        }
        public void Clear()
        {
            dictonary.Clear();
        }

        public IEnumerator GetEnumerator()
        {
            return dictonary.GetEnumerator();
        }

        public object this[string name]
        {
            get
            {
                return dictonary[name];
            }
            set
            {
                Put(name, value);
            }
        }
    }
}
