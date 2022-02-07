#if NITIS_EXTENSIONS
using System;
using System.Collections;
using System.Collections.Generic;

namespace NiTiS.Core.Additions
{
    public static class Additions
    {
        public static string TrimWhiteSpaceFromStartAndEnd(this string text)
        {
            return text.TrimEnd(' ').TrimStart(' ');
        }
        public static string FromArrayToString(this IEnumerable<string> enumerable)
        {
            string text = "";
            foreach (var item in enumerable)
            {
                text += item ?? "";
            }
            return text;
        }
        public static string Multiply(this string value, int repeat)
        {
            return String.Concat(System.Linq.Enumerable.Repeat(value, repeat));
        }
        public static IEnumerable<T2> ForEachElements<T1, T2>(this IEnumerable<T1> enumerable, Func<T1, T2> func)
        {
            foreach (var item in enumerable)
            {
                yield return func(item);
            }
        }
        public static void ForEachElements<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
            {
                action(item);
            }
        }
        public static void ForEachElements<T>(this IEnumerable enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
            {
                if (item is T validItem)
                {
                    action(validItem);
                }
            }
        }
        public static T[] ToArray<T>(this IEnumerable<T> enumerable)
        {
            List<T> list = new List<T>();
            foreach (T item in enumerable)
            {
                list.Add(item);
            }
            return list.ToArray();
        }
        public static T[] ToArray<T>(this IEnumerable enumerable)
        {
            List<T> list = new List<T>();
            foreach (T item in enumerable)
            {
                list.Add(item);
            }
            return list.ToArray();
        }
#if NITIS_ENUM_INFO
        public static string GetEnumValueName(this Enum enam)
        {
            Type enumType = enam.GetType();
            string name = enumType.GetEnumName(enam);
            try
            {
                Attributes.EnumInfoAttribute enumInfo = (Attributes.EnumInfoAttribute)enumType.GetMember(enam.ToString())[0].GetCustomAttributes(typeof(Attributes.EnumInfoAttribute), false)[0];
                if (enumInfo != null)
                {
                    return enumInfo.Name;
                }
                return name;
            }
            catch (Exception)
            {
                return name;
            }
        }
        public static string GetEnumValueDescription(this Enum enam)
        {
            Type enumType = enam.GetType();
            try
            {
                Attributes.EnumInfoAttribute enumInfo = (Attributes.EnumInfoAttribute)enumType.GetMember(enam.ToString())[0].GetCustomAttributes(typeof(Attributes.EnumInfoAttribute), false)[0];
                if (enumInfo != null)
                {
                    return enumInfo.Description;
                }
                return "";
            }
            catch (Exception)
            {
                return "";
            }
        }
#endif
        public static bool Invert(this bool value, bool invert = true)
        {
            return invert ? !value : value;
        }
    }
}
#endif