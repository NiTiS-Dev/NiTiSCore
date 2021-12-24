using System;

namespace NiTiS.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field 
        | AttributeTargets.Property 
        | AttributeTargets.Class 
        | AttributeTargets.Struct,
        AllowMultiple = false)]
    public sealed class NiTiSONIgnoreAttribute : Attribute
    {
        public static bool IsIgnore<T>()
        {
            NiTiSONIgnoreAttribute attribute = GetOf<T>();
            if (attribute is null) return false;
            return true;
        }
        public static bool IsIgnore(Type type)
        {
            NiTiSONIgnoreAttribute attribute = GetOf(type);
            if (attribute is null) return false;
            return true;
        }
        public static NiTiSONIgnoreAttribute GetOf<T>()
        {
            return typeof(T).GetCustomAttributes(typeof(NiTiSONIgnoreAttribute), false)[0] as NiTiSONIgnoreAttribute;
        }
        public static NiTiSONIgnoreAttribute GetOf(Type type)
        {
            try
            {
                return type.GetCustomAttributes(typeof(NiTiSONIgnoreAttribute), false)[0] as NiTiSONIgnoreAttribute;
            } 
            catch
            {
                return null;
            }
        }
        public NiTiSONIgnoreAttribute()
        {

        }
    }
}
