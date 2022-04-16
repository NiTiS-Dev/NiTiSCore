using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace NiTiS.Reflection;

public partial class Class
{
	public partial class PropertyList : IEnumerable<PropertyInfo>
	{
		private readonly Type tp;
		private readonly BindingFlags flags;
		public PropertyInfo? this[string name] => tp.GetProperty(name);
		public IEnumerator<PropertyInfo> GetEnumerator()
		{
			foreach (PropertyInfo info in tp.GetProperties(flags))
			{
				yield return info;
			}
		}
		IEnumerator IEnumerable.GetEnumerator() => tp.GetProperties(flags).GetEnumerator();
	}
}
