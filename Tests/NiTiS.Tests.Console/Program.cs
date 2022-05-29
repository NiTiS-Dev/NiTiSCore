using NiTiS.Collections.Generic;
using NiTiS.Math.Vectors;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

namespace NiTiS.Tests.Console
{
	public static class Program
	{
		private static void Main()
		{
			vec2 vector = new(2, 2);
			vec2 vector2 = new(1, 2);

			SC.WriteLine((vector + vector2).ToString());
			SC.WriteLine((vector - vector2).ToString());
			SC.WriteLine((vector * vector2).ToString());
			SC.WriteLine((vector / vector2).ToString());
		}
	}
}