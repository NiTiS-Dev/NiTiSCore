using NiTiS.Collections.Generic;

namespace NiTiS.Collections
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
