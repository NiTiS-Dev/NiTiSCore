using System;
using SMath = System.Math;

namespace NiTiS.Math;

/// <summary>
/// RNG created by Brian Wichmann and David Hill
/// </summary>
public sealed class WichmannRandom
{
	private double s1, s2, s3;
	public WichmannRandom(ushort seed)
	{
		if (seed > 30000)
		{
			throw new ArgumentOutOfRangeException(nameof(seed));
		}
		s1 = seed;
		s2 = seed + 1;
		s3 = seed + 2;
	}

	public double Next()
	{
		s1 = 171 * (s1 % 177) - 2 * (s1 / 177);
		if (s1 < 0) { s1 += 30269; }
		s2 = 172 * (s2 % 176) - 35 * (s2 / 176);
		if (s2 < 0) { s2 += 30307; }
		s3 = 170 * (s3 % 178) - 63 * (s3 / 178);
		if (s3 < 0) { s3 += 30323; }
		double r = (s1 * 1.0) / 30269 + (s2 * 1.0) / 30307 + (s3 * 1.0) / 30323;
		return r - SMath.Truncate(r);
	}
	public int this[int min, int max] => Next(min, max);
	public int this[int max] => Next(max);
	public int Next(int min, int max) => Next(max - min) + min;
	public int Next(int max) => (int)(max * Next());
}