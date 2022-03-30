using NiTiS.Additions;

namespace NiTiS.Booru.Gelbooru.Tags;

public class UserTag : SearchTag
{
	private readonly string userName;
	private readonly TagAccess access;
	public UserTag(string userName, TagAccess access)
	{
		this.userName = userName.ReplaceSelf(' ', '_');
		this.access = access;
	}
	public override string ToString() => $"{(access == TagAccess.Exclude ? "-":"")}user:{userName}";
}
