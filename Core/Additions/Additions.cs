using NiTiS.Core.Attributes;
using System;
using System.Collections.Generic;

namespace NiTiS.Core.Additions
{
    [NiTiSCoreTypeInfo("1.3.0.0", "2.0.0.0")]
    public static class Additions
    {
        public static string TrimWhiteSpaceFromStartAndEnd(this string text)
        {
            while(text[0] == ' ')
            {
                text = text.Substring(1);
            }
            while(text[text.Length - 1] == ' ')
            {
                text = text.TrimEnd(' ');
            }
            return text;
        }
        [Obsolete("Its old format")]
        public static string FormatForValueSet(this string text)
        {
            return text.Replace(":", @"\u003a").Replace("\r", @"\u000d").Replace("\n", @"\u000a");
        }
        [Obsolete("Its old format")]
        public static string FormatFromValueSet(this string text)
        {
            return text.Replace(@"\u003a", ":").Replace(@"\u000d", "\r").Replace(@"\u000a", "\n");
        }
        public static string FromArrayToString(this IEnumerable<string> enumerable)
        {
            string text = "";
            foreach(var item in enumerable)
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
        public static T[] ToArray<T>(this IEnumerable<T> enumerable)
        {
            List<T> list = new List<T>();
            foreach (T item in enumerable)
            {
                list.Add(item);
            }
            return list.ToArray();
        }
        public static string GetEnumValueName(this Enum enam)
        {
            Type enumType = enam.GetType();
            string name = enumType.GetEnumName(enam);
            try
            {
                EnumInfoAttribute enumInfo = (EnumInfoAttribute)enumType.GetMember(enam.ToString())[0].GetCustomAttributes(typeof(EnumInfoAttribute), false)[0];
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
                EnumInfoAttribute enumInfo = (EnumInfoAttribute)enumType.GetMember(enam.ToString())[0].GetCustomAttributes(typeof(EnumInfoAttribute), false)[0];
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
        public static bool Invert(this bool value, bool invert = true)
        {
            return invert ? !value : value;
        }
    }
}
