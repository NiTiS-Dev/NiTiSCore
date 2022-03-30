using System.Collections.Generic;
using System.Text;

namespace NiTiS.Booru.Net;

public sealed class AttributeCompound
{
	private readonly List<URLAttribute> attributeList;
	public AttributeCompound() => this.attributeList = new List<URLAttribute>(8);
	public AttributeCompound(IEnumerable<URLAttribute> attributes) => this.attributeList = new(attributes);
	public AttributeCompound Add(URLAttribute attribute)
	{
		this.attributeList.Add(attribute);
		return this;
	}
	public AttributeCompound AddRange(params URLAttribute[] attributes)
	{
		this.attributeList.AddRange(attributes);
		return this;
	}
	public AttributeCompound AddRange(IEnumerable<URLAttribute> attributes)
	{
		this.attributeList.AddRange(attributes);
		return this;
	}
	public static AttributeCompound Of(params URLAttribute[] attributes) => new(attributes);
	public override string ToString()
	{
		StringBuilder sb = new StringBuilder();
		sb.Append('?');
		foreach (URLAttribute a in this.attributeList)
		{
			sb.Append(a.ToString() + "&");
		}
		return 
			sb.Remove(sb.Length - 1, 1) //Remove last character (&)
			.ToString();
	}
}
