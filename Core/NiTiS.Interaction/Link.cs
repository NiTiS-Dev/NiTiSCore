namespace NiTiS.Interaction;

public sealed class Link<CONNECT>
{
	public CONNECT Value { get; set; }
	public Link(CONNECT value)
	{
		Value = value;
	}
}