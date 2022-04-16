using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NiTiS.Math.UnsafeConverter;

namespace NiTiS.Math;

public static class Comparer
{
	public static bool Equal(float left, float right, float tolerance) => SMath.Abs(left - right) < tolerance;
	public static bool Equal(double left, double right, double tolerance) => SMath.Abs(left - right) < tolerance;
	public static bool Equal(decimal left, decimal right, decimal tolerance) => SMath.Abs(left - right) < tolerance;
    public static bool ApproximatelyEqual(float left, float right, float epsilon)
    {
        // If they are equal anyway, just return True.
        if (left.Equals(right))
            return true;

        // Handle NaN, Infinity.
        if (Double.IsInfinity(left) | Double.IsNaN(left))
            return left.Equals(right);
        else if (Double.IsInfinity(right) | Double.IsNaN(right))
            return left.Equals(right);

        // Handle zero to avoid division by zero
        double divisor = SMath.Max(left, right);
        if (divisor.Equals(0))
            divisor = SMath.Min(left, right);

        return SMath.Abs(left - right) / divisor <= epsilon;
    }
    public static bool ApproximatelyEqual(double left, double right, double epsilon)
    {
        // If they are equal anyway, just return True.
        if (left.Equals(right))
            return true;

        // Handle NaN, Infinity.
        if (Double.IsInfinity(left) | Double.IsNaN(left))
            return left.Equals(right);
        else if (Double.IsInfinity(right) | Double.IsNaN(right))
            return left.Equals(right);

        // Handle zero to avoid division by zero
        double divisor = SMath.Max(left, right);
        if (divisor.Equals(0))
            divisor = SMath.Min(left, right);

        return SMath.Abs(left - right) / divisor <= epsilon;
    }
}
