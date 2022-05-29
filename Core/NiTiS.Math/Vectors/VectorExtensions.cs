// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiTiS.Math.Vectors;
public static class VectorExtensions
{
	public static double LengthSquared(this Vector2D<Single> vec)
		=> (vec.x * vec.x) + (vec.y * vec.y);
	public static double Length(this Vector2D<Single> vec) => SMath.Sqrt(vec.LengthSquared());
	public static double LengthSquared(this Vector2D<Double> vec)
		=> (vec.x * vec.x) + (vec.y * vec.y);
	public static double Length(this Vector2D<Double> vec) => SMath.Sqrt(vec.LengthSquared());
}
