using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace NiTiS.Reflection;

public partial class Class
{
	public partial class ConstructorList : IEnumerable<ConstructorInfo>
	{
		private readonly Type tp;
		private readonly BindingFlags flags;
		public ConstructorInfo? this[params Type[] types] => tp.GetConstructor(types);
		public ConstructorInfo? Free() 
			=> tp.GetConstructor(Type.EmptyTypes);
		public IEnumerator<ConstructorInfo> GetEnumerator()
		{
			foreach (ConstructorInfo info in tp.GetConstructors(flags))
			{
				yield return info;
			}
		}

		IEnumerator IEnumerable.GetEnumerator() => tp.GetConstructors(flags).GetEnumerator();
	}
}