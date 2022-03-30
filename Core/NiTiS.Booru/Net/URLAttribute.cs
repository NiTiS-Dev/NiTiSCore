namespace NiTiS.Booru.Net;

public abstract class URLAttribute
{
	public abstract string Name { get; }
	public abstract string Value { get; }
	public override string ToString() => $"{Name}={Value}";
}
