using System;

namespace NiTiS.Additions;

public static class EnumInfo
{
    public static string GetSpecialName(this Enum enam)
    {
        Type enumType = enam.GetType();
        string? name = enumType.GetEnumName(enam);
        try
        {
            EnumInfoAttribute enumInfo = (EnumInfoAttribute)enumType.GetMember(enam.ToString())[0].GetCustomAttributes(typeof(EnumInfoAttribute), false)[0];
            if (enumInfo != null) return enumInfo.Name;
        }
        catch (Exception) { }
        return name ?? "";
    }
    public static string GetSpecialDescription(this Enum enam)
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
}