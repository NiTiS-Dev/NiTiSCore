using NiTiS.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace NiTiS.Reflection;

[DebuggerStepThrough]
public partial class Class
{
	public Type Type { get; }
	public FieldList Fields { get; }
	public FieldList StaticFields { get; }
	public PropertyList Properties { get; }
	public PropertyList StaticProperties { get; }
	public MethodList Methods { get; }
	public MethodList StaticMethods { get; }
	public Class(Type type)
	{
		Type = type;
		Fields = new(Type
			, BindingFlags.Instance
			| BindingFlags.IgnoreCase
			| BindingFlags.Public
			| BindingFlags.NonPublic
			);
		StaticFields = new(Type
			, BindingFlags.Static
			| BindingFlags.IgnoreCase
			| BindingFlags.Public
			| BindingFlags.NonPublic
			);
		Properties = new(Type
			, BindingFlags.Instance
			| BindingFlags.IgnoreCase
			| BindingFlags.Public
			| BindingFlags.NonPublic
			);
		StaticProperties = new(Type
			, BindingFlags.Static
			| BindingFlags.IgnoreCase
			| BindingFlags.Public
			| BindingFlags.NonPublic
			);
		Methods = new(Type
			, BindingFlags.Instance
			| BindingFlags.IgnoreCase
			| BindingFlags.Public
			| BindingFlags.NonPublic
			);
		StaticMethods = new(Type
			, BindingFlags.Static
			| BindingFlags.IgnoreCase
			| BindingFlags.Public
			| BindingFlags.NonPublic
			);
	}
	public Class(object itm)
	{
		Type = itm.GetType();
		Fields = new(Type
			, BindingFlags.Instance
			| BindingFlags.IgnoreCase
			| BindingFlags.Public
			| BindingFlags.NonPublic
			);
		StaticFields = new(Type
			, BindingFlags.Static
			| BindingFlags.IgnoreCase
			| BindingFlags.Public
			| BindingFlags.NonPublic
			);
		Properties = new(Type
			, BindingFlags.Instance
			| BindingFlags.IgnoreCase
			| BindingFlags.Public
			| BindingFlags.NonPublic
			);
		StaticProperties = new(Type
			, BindingFlags.Static
			| BindingFlags.IgnoreCase
			| BindingFlags.Public
			| BindingFlags.NonPublic
			);
		Methods = new(Type
			, BindingFlags.Instance
			| BindingFlags.IgnoreCase
			| BindingFlags.Public
			| BindingFlags.NonPublic
			);
		StaticMethods = new(Type
			, BindingFlags.Static
			| BindingFlags.IgnoreCase
			| BindingFlags.Public
			| BindingFlags.NonPublic
			);
	}
	public static Class Of<T>() => new(typeof(T));
	public static Class Of(object itm) => new(itm);
	public FieldInfo? GetField(Environment env, string name)
	{
		IEnumerable<FieldInfo> fields = null;
		if (env.HasFlag(Environment.Exclusive))
		{
			fields ??= Array.Empty<FieldInfo>();
			fields.AppendRange(Fields);
		}
		if (env.HasFlag(Environment.Static))
		{
			fields ??= Array.Empty<FieldInfo>();
			fields.AppendRange(StaticFields);
		}
		foreach (FieldInfo info in fields)
		{
			if (info.Name == name) return info;
		}
		return null;
	}
	public PropertyInfo? GetProperty(Environment env, string name)
	{
		IEnumerable<PropertyInfo> properties = null;
		if (env.HasFlag(Environment.Exclusive))
		{
			properties ??= Array.Empty<PropertyInfo>();
			properties.AppendRange(Properties);
		}
		if (env.HasFlag(Environment.Static))
		{
			properties ??= Array.Empty<PropertyInfo>();
			properties.AppendRange(StaticProperties);
		}
		foreach (PropertyInfo info in properties)
		{
			if (info.Name == name) return info;
		}
		return null;
	}
	public MethodInfo? GetMethod(Environment env, string name)
	{
		IEnumerable<MethodInfo> methods = null;
		if (env.HasFlag(Environment.Exclusive))
		{
			methods ??= Array.Empty<MethodInfo>();
			methods.AppendRange(Methods);
		}
		if (env.HasFlag(Environment.Static))
		{
			methods ??= Array.Empty<MethodInfo>();
			methods.AppendRange(StaticMethods);
		}
		foreach (MethodInfo info in methods)
		{
			if (info.Name == name) return info;
		}
		return null;
	}
	public IEnumerable<FieldInfo> GetFields(Environment env)
	{
		if (env.HasFlag(Environment.Exclusive))
		{
			foreach (FieldInfo info in Fields)
			{
				yield return info;
			}
		}
		if(env.HasFlag(Environment.Static))
		{
			foreach (FieldInfo info in StaticFields)
			{
				yield return info;
			}
		}
	}
	public IEnumerable<PropertyInfo> GetProperties(Environment env)
	{
		if (env.HasFlag(Environment.Exclusive))
		{
			foreach (PropertyInfo info in Properties)
			{
				yield return info;
			}
		}
		if (env.HasFlag(Environment.Static))
		{
			foreach (PropertyInfo info in StaticProperties)
			{
				yield return info;
			}
		}
	}
	public IEnumerable<MethodInfo> GetMethods(Environment env)
	{
		if (env.HasFlag(Environment.Exclusive))
		{
			foreach (MethodInfo info in Methods)
			{
				yield return info;
			}
		}
		if (env.HasFlag(Environment.Static))
		{
			foreach (MethodInfo info in StaticMethods)
			{
				yield return info;
			}
		}
	}
	public partial class FieldList
	{
		internal FieldList(Type tp, BindingFlags options)
		{
			this.tp = tp;
			this.flags = options;
		}
	}
	public partial class MethodList
	{
		internal MethodList(Type tp, BindingFlags flags)
		{
			this.tp = tp;
			this.flags = flags;
		}
	}
	public partial class PropertyList
	{
		internal PropertyList(Type tp, BindingFlags flags)
		{
			this.tp = tp;
			this.flags = flags;
		}
	}

	/// <summary>
	/// Member location
	/// </summary>
	[Flags]
	public enum Environment : byte
	{
		/// <summary>
		/// One on one object
		/// </summary>
		Exclusive = 1,
		/// <summary>
		/// One on all objects
		/// </summary>
		Static = 2,
	}
}