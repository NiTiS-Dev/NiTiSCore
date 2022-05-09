using NiTiS.Math.Vectors;

namespace NiTiS.Math;

public static class VectorMath
{
	internal static float Normalize(float value)
	{
		if (value == 0f) return 0f;
		if (value < 0f) return -1f; else return 1f; 
	}
	internal static int Normalize(int value)
	{
		if (value == 0) return 0;
		if (value < 0) return -1; else return 1;
	}
	public static bool CompareVectors<T>(IVector<T> left, IVector<T> right, params Axis[] axis)
	{
		foreach (Axis i in axis)
		{
			if (!left.GetValueByDimension(i)!.Equals(right.GetValueByDimension(i)))
				return false;
		}
		return true;
	}
}