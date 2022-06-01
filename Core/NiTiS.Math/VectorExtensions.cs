// The NiTiS-Dev licenses this file to you under the MIT license.


/* Необъединенное слияние из проекта "NiTiS.Math (netstandard2.1)"
До:
using System;
После:
using NiTiS;
using NiTiS.Math;
using NiTiS.Math;
using NiTiS.Math.Vectors;
using System;
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiTiS.Math;
public static class VectorExtensions
{
	public static double LengthSquared(this Vector2D<float> vec)
		=> vec.x * vec.x + vec.y * vec.y;
	public static double Length(this Vector2D<float> vec) => SMath.Sqrt(vec.LengthSquared());
	public static double LengthSquared(this Vector2D<double> vec)
		=> vec.x * vec.x + vec.y * vec.y;
	public static double Length(this Vector2D<double> vec) => SMath.Sqrt(vec.LengthSquared());
}
