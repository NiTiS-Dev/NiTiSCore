using NiTiS.Booru.Gelbooru.Tags;
using NiTiS.Booru.Net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace NiTiS.Booru.Gelbooru;

public class GelbooruPostsRequest
{
	private readonly GelbooruSite site;
	private readonly List<SearchTag> searchTags = new();
	private readonly List<URLAttribute> attributes = new();
	internal GelbooruPostsRequest(GelbooruSite site) { this.site = site; }
	public GelbooruPostsRequest WithAPIAttributes()
	{
		attributes.Add(new ParamAttribute("page", "dapi"));
		attributes.Add(new ParamAttribute("q", "index"));
		attributes.Add(new ParamAttribute("s", "post"));
		return this;
	}
	public GelbooruPostsRequest WithTag(SearchTag tag)
	{
		this.searchTags.Add(tag);
		return this;
	}
	public GelbooruPostsRequest WithTags(params SearchTag[] tags)
	{
		this.searchTags.AddRange(tags);
		return this;
	}
	public GelbooruPostsRequest WithTags(IEnumerable<SearchTag> tags)
	{
		this.searchTags.AddRange(tags);
		return this;
	}

	public List<GelbooruPost> GetPosts()
	{
		List<GelbooruPost> posts = new(100);
		StringBuilder sb = new();
		sb.Append('?');
		attributes.Add(new ParamAttribute("tag", GenTags()));
		foreach (URLAttribute attribute in attributes)
		{
			sb.Append(attribute.ToString() + "&");
		}
		string path = sb.Remove(sb.Length - 1, 1).ToString();
		Console.WriteLine(path);
		XmlDocument xml = site.AsyncGetXml(path).GetAwaiter().GetResult();
		foreach (XmlNode node in xml.GetElementsByTagName("posts").Item(0).ChildNodes)
		{
			//Console.WriteLine(node.);
			//posts.Add(new(node.));
		}
		return posts;
	}
	private string GenTags()
	{
		StringBuilder sb = new();
		foreach(SearchTag tag in searchTags)
		{
			sb.Append(tag.ToString() + " ");
		}
		return sb.ToString();
	}
}
