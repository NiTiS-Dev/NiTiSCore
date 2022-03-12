using System;
using System.Collections;
using System.Collections.Generic;

namespace NiTiS.Collections;
public class EnumCollection<ET> : IEnumerable where ET : struct, Enum
{
    protected List<ET> list = new List<ET>();
    public static EnumCollection<Enu> Of<Enu>(params Enu[] enums) where Enu : struct, Enum
    {
        var enumCollection = new EnumCollection<Enu>();
        enumCollection.list.AddRange(enums);
        return enumCollection;
    }
    public static EnumCollection<Enu> Of<Enu>() where Enu : struct, Enum
    {
        var values = Enum.GetValues(typeof(Enu));
        return new EnumCollection<Enu>(values);
    }
    private EnumCollection() { }
    private EnumCollection(Array array)
    {
        if (array is null) return;
        foreach (ET enu in array)
        {
            list.Add(enu);
        }
    }
    public IEnumerator GetEnumerator()
    {
        return list.GetEnumerator();
    }
}