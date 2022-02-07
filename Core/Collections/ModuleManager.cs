using NiTiS.Core.Additions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.Core.Collections;

public class ModuleManager<M> : ICollection<M>
{
    private HardTypedDictonary dictonary = new();

    public int Count => dictonary.Count;

    public bool IsReadOnly => false;

    public void Add(M item)
    {
        dictonary.Add(item);
    }

    public void Clear()
    {
        dictonary.Clear();
    }

    public bool Contains(M item)
    {
        return dictonary.Exists(item);
    }

    public void CopyTo(M[] array, int arrayIndex)
    {
#if NITIS_EXTENSIONS
        M[] arr = dictonary.Dictonary.ToArray<M>();
#else
        M[] arr = new M[Count];
        int index = 0;
        foreach(M item in this)
        {
            arr[index] = item;
            index++;
        }
#endif

        for(int i = arrayIndex; i < arr.Length; i++)
        {
            array[i + arrayIndex] = arr[i];
        }
    }

    public IEnumerator<M> GetEnumerator()
    {
        foreach(M module in dictonary)
        {
            yield return module;
        }
    }

    public bool Remove(M item)
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return dictonary.GetEnumerator();
    }
}