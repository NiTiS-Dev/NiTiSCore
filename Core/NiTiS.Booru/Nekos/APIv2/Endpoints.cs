// The NiTiS-Dev licenses this file to you under the MIT license.

using static NiTiS.Booru.Nekos.APIv2.Endpoint;

namespace NiTiS.Booru.Nekos.APIv2;
public static class Endpoints
{
	public static class SFW
	{
		public static readonly Endpoint
			Neko,
			NekoGif,
			Fox,
			Holo,
			PatGif,
			PokeGif,
			HugGif,
			CuddleGif,
			KissGif,
			FeedGif,
			TickleGif,
			SmugGif,
			BakaGif,
			SlapGif,
			RealCat,
			RealDog,
			RealLizard,
			RealGoose,
			Waifu;
		static SFW()
		{
			Neko = SFW("neko");
			NekoGif = SFW("ngif");
			Fox = SFW("fox");
			Holo = SFW("holo");
			PatGif = SFW("pat");
			PokeGif = SFW("poke");
			HugGif = SFW("hug");
			CuddleGif = SFW("cuddle");
			KissGif = SFW("kiss");
			FeedGif = SFW("feed");
			TickleGif = SFW("tickle");
			SmugGif = SFW("smug");
			BakaGif = SFW("baka");
			SlapGif = SFW("slap");
			RealCat = SFW("meow");
			RealDog = SFW("woof");
			RealLizard = SFW("lizard");
			RealGoose = SFW("goose");
			Waifu = SFW("waifu");
		}
	}
}
public struct Endpoint
{
	public readonly string filter;
	public readonly bool nsfw;
	public Endpoint(string filter, bool nsfw = true)
	{
		this.filter = filter;
		this.nsfw = nsfw;
	}
	public static Endpoint NSFW(string filter) => new(filter, true);
	public static Endpoint SFW(string filter) => new(filter, false);
}
