using System;

namespace NiTiS.Booru.Gelbooru.Tags;

public class SourceTag : SearchTag
{
	private readonly string source;
	private readonly TagAccess access;
	public SourceTag(string source, TagAccess access)
	{
		if (source.Contains(' ')) throw new ArgumentException("Whitespace is not allowed", nameof(source));
		this.source = source;
		this.access = access;
	}
	public override string ToString() => $"{(access == TagAccess.Exclude ? "-":"")}source:{source}";
}
