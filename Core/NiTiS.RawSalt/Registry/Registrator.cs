using NiTiS.Collections.Generic;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace NiTiS.RawSalt.Registry;
public static class Registrator<T> where T : IEquatable<T>
{
	private static Idendifier[] ids;
	private static T[] items;
	private static int count;
	private static int size;
	public static int Size => size;
	public static int Count => count;
	public static int GetIndex(Idendifier id)
	{
		int index = 0;
		foreach(Idendifier other in ids.Where( s => s is not null))
		{
			if (other == id) return index;
			index++;
		}
		return -1;
	}
	public static int GetIndexOf(T item)
	{
		int index = 0;
		foreach (T other in items)
		{
			if (other.Equals(item)) return index;
			index++;
		}
		return -1;
	}
	public static bool Exists(Idendifier id) => GetIndex(id) != -1;
	public static bool Exists(T item) => GetIndexOf(item) != -1;
	public static bool TryGet(Idendifier id, out T? value)
	{
		int index = GetIndex(id);
		if (index != -1)
		{
			value = items[index];
			return true;
		}
		value = default;
		return false;
	}
	public static T? Get(Idendifier id)
	{
		if (Idendifier.IsNull(id))
		{
			return default;
		}
		int index = GetIndex(id);
		return index != -1 ? items[index] : default;
	}
	public static void Registry(RegistryKey<T> key)
	{
		if (CanRegistry(key.ID))
		{
			CheckArrays();
			ids[count] = key.ID;
			items[count] = key.Value;
			count++;
		} else
		{
			throw new ArgumentException("ID allready registred or equals null");
		}
	}
	public static bool CanRegistry(Idendifier id)
	{
		if (Idendifier.IsNull(id)) return false;
		if (Exists(id)) return false;
		return true;
	}
	private static void CheckArrays()
	{
		int idL = ids.Length;
		int itL = items.Length;
		if (idL != itL)
		{
			RecreateArrays();
#if DEBUG
			Environment.Exit((int)RawSaltExitCodes.REGISTRY_ARRAY_EXCEPTION);
			//TODO: Create custom env exit
#endif
		}
		if (count >= size)
		{
			Idendifier[] newIds = new Idendifier[size * 2];
			T[] newItems = new T[size * 2];
			ids.CopyTo(newIds, 0);
			items.CopyTo(newItems, 0);

			size *= 2;

			ids = newIds;
			items = newItems;
		}
	}
	private static void RecreateArrays()
	{
		ids = new Idendifier[16];
		items = new T[16];
		count = 0;
		size = 16;
	}
	static Registrator()
	{
		ids = new Idendifier[16];
		items = new T[16];
		count = 0;
		size = 16;
	}
}
