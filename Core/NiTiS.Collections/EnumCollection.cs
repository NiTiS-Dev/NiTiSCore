using System;
using System.Collections;
using System.Collections.Generic;

namespace NiTiS.Collections;
public class EnumCollection<ET> : IEnumerable<ET> where ET : struct, Enum
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
        Enu[] values = (Enu[])Enum.GetValues(typeof(Enu));
        return new EnumCollection<Enu>(values);
    }
    private EnumCollection() { }
    private EnumCollection(ET[] array)
    {
        if (array is null) return;
        foreach (ET enu in array)
        {
            list.Add(enu);
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return list.GetEnumerator();
    }

    public IEnumerator<ET> GetEnumerator()
    {
        throw new NotImplementedException();
    }
}