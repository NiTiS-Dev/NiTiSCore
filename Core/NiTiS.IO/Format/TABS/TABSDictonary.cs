using NiTiS.Additions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiTiS.IO.Format.TABS;

public class TABSDictonary : Dictionary<TABSJustValue, TABSElement>, TABSElement
{
	public override string ToString() => ToString(0);
	public string ToString(int depth)
	{
		StringBuilder builder = new();
		builder.Append("{");
		int index = 0;
		foreach(KeyValuePair<TABSJustValue, TABSElement> pair in this)
		{
			if (index++ > 0)
			{
				builder.Append(',');
			}
			builder.Append("\n");
			builder.Append(" ".Multiply(depth * 2));
			builder.Append("[" + pair.Key.ToString() + "]");
			builder.Append(" = ");
			builder.Append(pair.Value.ToString(depth + 1));
		}
		builder.Append('\n');
		builder.Append(" ".Multiply((depth - 1) * 2));
		builder.Append('}');
		return builder.ToString();
	}
}
