namespace NiTiS.Interaction;
public sealed class ReadonlyLink<CONNECT>
{
	public CONNECT Value { get; private set; }
	public ReadonlyLink(CONNECT value)
	{
		Value = value;
	}
}