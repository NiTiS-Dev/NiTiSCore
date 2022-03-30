namespace NiTiS.Booru;

public enum Comparer : byte
{
	Equals = 0,
	NotEquals = 1,
	Less = 2,
	More = 3,
	LessOrEquals = 4,
	MoreOrEquals = 5,
}
public static class ComparerExtensions
{
	public static string GetTextStyle(this Comparer comparer) => comparer switch
	{
		Comparer.Equals => "=",
		Comparer.NotEquals => "!=",
		Comparer.Less => "<",
		Comparer.More => ">",
		Comparer.LessOrEquals => "<=",
		Comparer.MoreOrEquals => ">=",
		_ => "?",
	};
}