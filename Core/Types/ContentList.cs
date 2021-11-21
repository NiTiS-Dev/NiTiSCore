using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NiTiS.Core.Types
{
    public interface ContentList<T>
    {
        public void Load();
    }
    public interface IReturnAllElements<T>
    {
        public List<T> GetAllElements()
        {
            var g = GetType().GetFields();
            List<object> list = new List<object>();
            foreach (FieldInfo field in g)
            {
                var obj = field.GetValue(this);
                if (obj?.GetType() == typeof(T))
                {
                    list.Add(obj);
                }
            }
            return list.OfType<T>().ToList();
        }
        public List<T> GetElements();
    }
}
