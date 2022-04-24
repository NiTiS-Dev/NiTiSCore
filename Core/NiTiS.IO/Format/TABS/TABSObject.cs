using System.Collections;
using System.Collections.Generic;
using System.Text;
using NiTiS.Additions;

namespace NiTiS.IO.Format.TABS;

public class TABSObject : TABSElement, IEnumerable<TABSElement>
{
	public const int MAX_DEPTH = 120;
	private Dictionary<string, TABSElement> elements = new(4);
	public void AddField(string name, TABSElement element)
	{
		elements.Add(name, element);
	}
	public void RemoveField(string name)
	{
		elements.Remove(name);
	}
	public IEnumerator<TABSElement> GetEnumerator() => this.elements.Values.GetEnumerator();
	IEnumerator IEnumerable.GetEnumerator() => this.elements.Values.GetEnumerator();
	public override string ToString() => ToString(0);
	public string ToString(int depth)
	{
		StringBuilder builder = new();
		if (depth > 0)
		{
			builder.Append('\n');
		}
		if (depth > MAX_DEPTH)
		{
			return "null";
		}
		foreach(KeyValuePair<string, TABSElement> element in elements)
		{
			builder.Append(" ".Multiply(depth *2) + element.Key + ": " + element.Value.ToString(depth + 1) + "\n");
		}
		return builder.ToString();
	}
}
