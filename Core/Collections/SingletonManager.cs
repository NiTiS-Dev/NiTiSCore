using NiTiS.Core.Collections.Generic;
using System;

namespace NiTiS.Core.Collections
{
    public static class SingletonManager
    {
        private static volatile HardTypedDictonary dictonary = new HardTypedDictonary();
        public static T GetInstance<T>()
        {
            return dictonary.Get<T>();
        }
        public static void AddInstance<T>(T instance)
        {
            dictonary.Add(instance);
        }
    }
}
