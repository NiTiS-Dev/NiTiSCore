using System;
using System.Reflection;


namespace NiTiS.Core.Data
{
#if NITIS_SERIALIZATION
    public static class BinaryFormat
    {
        public static byte[] Format(IData item)
        {
            BinaryDataStorage bin = BinaryDataStorage.CreateForWrite();
            item.Write(bin);
            return bin.FinishRead();
        }
#nullable enable
        public static T? Restore<T>(byte[] bytes) where T : IData
        {
            Type type = typeof(T);
#pragma warning disable
            ConstructorInfo construct = type.GetConstructor(new Type[] { typeof(IDataStorage) });
#pragma warning restore
            if (construct is null)
            {
                return default;
            }
            else
            {
                return (T?)construct.Invoke(new object[] { BinaryDataStorage.CreateForRead(bytes) });
            }
        }
#nullable disable
    }
#endif
}