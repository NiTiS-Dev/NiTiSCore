namespace NiTiS.Booru.Net;

public class ParamAttribute : URLAttribute
{
	public ParamAttribute(string name, string value)
	{
		Name = name;
		Value = value;
	}
	public override string Name { get; }
	public override string Value { get; }
}
