using NiTiS.Booru.Gelbooru;
using NiTiS.Booru.Gelbooru.Tags;
using NiTiS.Interaction;
using System.Xml;
using SC = System.Console;

namespace NiTiS.Tests.Console
{
	public class Program
	{
		private static unsafe void Main(string[] args)
		{
			Link<string> linkk = Link<string>.Of("");
			GelbooruSite site = new();
			GelbooruPostsRequest request = site.CreateRequest();
			request
				.WithAPIAttributes()
				.WithTags(
				new RatingTag(Rating.Explicit, TagAccess.Include),
				new RatingTag(Rating.Questionable, TagAccess.Include)
				)
				.GetPosts();
		}
	}
}