﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace NiTiS.Collections.Generic;

public class HardTypedDictonary : HardTypedDictonary<object> { }
public class HardTypedDictonary<M> : IEnumerable
{
    private Dictionary<Type, M> dict = new();

    public HardTypedDictonary() { }
    public HardTypedDictonary(IEnumerable<M> items)
    {
        foreach (var item in items)
        {
            dict.Add(item.GetType(), item);
        }
    }

    public void Add<T>(T obj) where T : M
    {
        dict.Add(typeof(T), obj);
    }

    public void Clear()
    {
        dict.Clear();
    }
    public int Count => dict.Count;
    public bool Exists<T>(T item)
    {
        return dict.ContainsKey(typeof(T));
    }

    internal Dictionary<Type, M> Dictonary => dict;

    public T Get<T>() where T : M
    {
        return (T)dict[typeof(T)];
    }

    public IEnumerator GetEnumerator()
    {
        return dict.GetEnumerator();
    }
    public IEnumerator<M> GetEnumeratorAsList()
    {
        foreach (var item in dict)
        {
            yield return item.Value;
        }
    }
    public IEnumerator<M> GetEnumeratorFromValues()
    {
        return dict.Values.GetEnumerator();
    }

    public bool Remove(Type item)
    {
        return dict.Remove(item);
    }
}