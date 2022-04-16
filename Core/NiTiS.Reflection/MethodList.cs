using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace NiTiS.Reflection;

public partial class Class
{
	public partial class MethodList : IEnumerable<MethodInfo>
	{
		private readonly Type tp;
		private readonly BindingFlags flags;
		public MethodInfo? this[string name] => tp.GetMethod(name, flags);
		public IEnumerator<MethodInfo> GetEnumerator()
		{
			foreach (MethodInfo info in tp.GetMethods(flags))
			{
				yield return info;
			}
		}
		IEnumerator IEnumerable.GetEnumerator() => tp.GetMethods(flags).GetEnumerator();
	}
}
