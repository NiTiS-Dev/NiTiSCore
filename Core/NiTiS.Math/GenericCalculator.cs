// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Linq.Expressions;

namespace NiTiS.Math;

public static class GenericCalculator<T, TOther, TOut>
{
	public static readonly Func<T, TOther, TOut> Addition, Substract, Divide, Multiply;
	static GenericCalculator()
	{
		ParameterExpression par1 = Expression.Parameter(typeof(T));
		ParameterExpression par2 = Expression.Parameter(typeof(TOther));

		BinaryExpression op_add = Expression.Add(par1, par2);
		BinaryExpression op_div = Expression.Divide(par1, par2);
		BinaryExpression op_sub = Expression.Subtract(par1, par2);
		BinaryExpression op_mul = Expression.Multiply(par1, par2);

		Addition = Expression.Lambda<Func<T, TOther, TOut>>(op_add, par1, par2).Compile();
		Divide = Expression.Lambda<Func<T, TOther, TOut>>(op_div, par1, par2).Compile();
		Substract = Expression.Lambda<Func<T, TOther, TOut>>(op_sub, par1, par2).Compile();
		Multiply = Expression.Lambda<Func<T, TOther, TOut>>(op_mul, par1, par2).Compile();
	}
}
public static class GenericCalculator<T, TOut>
{
	public static readonly Func<T, TOut> Negation;
	static GenericCalculator()
	{
		ParameterExpression par1 = Expression.Parameter(typeof(T));

		UnaryExpression op_neg = Expression.Negate(par1);

		Negation = Expression.Lambda<Func<T, TOut>>(op_neg, par1).Compile();
	}
}
