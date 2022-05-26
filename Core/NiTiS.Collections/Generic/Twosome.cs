using System;

namespace NiTiS.Collections.Generic;

public class Twosome<L, R>
{
	private L left;
	private R right;

	public L Left
	{
		get { return left; }
		set { left = value; }
	}
	public R Right
	{
		get { return right; }
		set { right = value; }
	}
	public Twosome(L left, R right)
	{
		this.left = left;
		this.right = right;
	}

	public override string ToString()
	{
		return "[" + left + " : " + right + "]";
	}
	public string ToString(Func<L, R, string> concat)
	{
		return concat(left, right);
	}
}
