namespace NiTiS.Booru.Gelbooru.Tags;

public class SizeTag : SearchTag
{
	private readonly Comparer comparer;
	private readonly Dimension dimension;
	private readonly ushort value;
	public SizeTag(Dimension dism, Comparer comparer, ushort value)
	{
		this.comparer = comparer;
		this.dimension = dism;
		this.value = value;
	}
	public override string ToString() => $"{(dimension == Dimension.Width ? "width" : "hieght")}:{comparer.GetTextStyle()}{value}";
	public enum Dimension : byte
	{
		Width = 0,
		Height = 1,
	}
}
