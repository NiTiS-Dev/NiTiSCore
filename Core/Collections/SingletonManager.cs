using NiTiS.Core.Attributes;
using System;

namespace NiTiS.Core.Collections
{
    [NiTiSCoreTypeInfo("1.5.0.0", "2.0.0.0")]
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
