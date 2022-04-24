using NiTiS.Additions;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.IO.Format.TABS;

public class TABSList : List<TABSElement>, TABSElement
{
	public TABSList() : base() { }
	public TABSList(IEnumerable<TABSElement> elements) : base(elements) { }
	public override string ToString() => ToString(0);
	public string ToString(int depth)
	{
		StringBuilder builder = new();
		builder.Append('[');
		int index = 0;
		foreach (TABSElement item in this)
		{
			if (index++ > 0)
			{
				builder.Append(',');
			}
			builder.Append('\n');
			builder.Append(" ".Multiply(Math.Max(1, depth) * 2) + item.ToString(depth));
		}
		builder.Append("\n");
		builder.Append(" ".Multiply( (depth -1) * 2));
		builder.Append("]");
		return builder.ToString();
	}
}
