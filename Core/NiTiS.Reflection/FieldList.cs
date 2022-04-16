using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace NiTiS.Reflection;

public partial class Class
{
	public partial class FieldList : IEnumerable<FieldInfo>
	{
		private readonly Type tp;
		private readonly BindingFlags flags;
		public FieldInfo? this[string name] => tp.GetField(name, flags);
		public object? this[string name, object? obj]
		{
			set => tp.GetField(name, flags)?.SetValue(obj, value);
		}

		public IEnumerator<FieldInfo> GetEnumerator()
		{
			foreach (FieldInfo info in tp.GetFields(flags))
			{
				yield return info;
			}
		}
		IEnumerator IEnumerable.GetEnumerator() => tp.GetFields(flags).GetEnumerator();
	}
}
