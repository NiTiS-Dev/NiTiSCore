using System;

namespace NiTiS.Booru.Gelbooru;

public class GelbooruSite : BooruSite
{
	public const string SITE_URL = "https://gelbooru.com/index.php";
	public string? ApiKey { get; }
	public string? UserID { get; }
	public GelbooruSite(string? apiKey = null, string? userID = null) : base(new())
	{
		base.client.BaseAddress = new Uri(SITE_URL);
		ApiKey = apiKey;
		UserID = userID;
	}
	public GelbooruPostsRequest CreateRequest() => new(this);
	public string Get(string uri)
	{
		string content = client.GetStringAsync(uri).Result;
		return content;
	}
}