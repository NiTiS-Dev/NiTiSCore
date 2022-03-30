using NiTiS.Additions;

namespace NiTiS.Booru.Gelbooru.Tags;

public class TextTag : SearchTag
{
	private readonly string text;
	private readonly TagAccess access;
	public TextTag(string theme, TagAccess access)
	{
		this.text = theme.ReplaceSelf(' ', '_');
		this.access = access;
	}
	public override string ToString() => $"{(access == TagAccess.Exclude ? "-":"")}{text}";
}
