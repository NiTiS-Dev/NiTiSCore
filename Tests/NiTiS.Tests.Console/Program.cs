using NiTiS.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

namespace NiTiS.Tests.Console
{
	public static unsafe class Program
	{
		private static void Main()
		{
			vec2 vector = new(2, 2);
			vec2 vector2 = new(1, 2);
			int size = sizeof(vec2i);
			SC.WriteLine(size);
		}
	}
}