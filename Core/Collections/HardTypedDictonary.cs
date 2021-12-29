using System;
using System.Collections;
using System.Collections.Generic;

namespace NiTiS.Core.Collections.Generic
{
    public class HardTypedDictonary : IEnumerable
    {
        private Dictionary<Type, object> dict = new Dictionary<Type, object>();

        public HardTypedDictonary() { }

        public void Add<T>(T obj)
        {
            dict.Add(typeof(T), obj);
        }
        public bool Exists<T>()
        {
            return dict.ContainsKey(typeof(T));
        }
        public T Get<T>()
        {
            return (T)dict[typeof(T)];
        }

        public IEnumerator GetEnumerator()
        {
            return dict.GetEnumerator();
        }
    }
}
