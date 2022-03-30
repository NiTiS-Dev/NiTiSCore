using System;
using System.Xml;

namespace NiTiS.Booru.Gelbooru;

public sealed class GelbooruPost : Post
{
	public GelbooruPost(XmlElement xml)
	{
		ID = Int32.Parse(xml.GetAttribute("id"));
		CreationTime = DateTime.Parse(xml.GetAttribute("created_at"));
		MD5 = xml.GetAttribute("md5");
	}
	public int ID { get; internal set; }
	public DateTime CreationTime { get; internal set; }
	public string Owner { get; internal set; }
	public int CreatorID { get; internal set; }
	public int ImageWidth { get; internal set; }
	public int PreviewWidth { get; internal set; }
	public int SampleWidth { get; internal set; }
	public int ImageHieght { get; internal set; }
	public int PreviewHieght { get; internal set; }
	public int SampleHieght { get; internal set; }
	public int Score { get; internal set; }
	public string? SourceUrl { get; internal set; }
	public string? Title { get; internal set; }
	public string MD5 { get; internal set; }
	public string Directory { get; internal set; }
	public string Image { get; internal set; }
	public string[] Tags { get; internal set; }
	public bool HasTags { get; internal set; }
	public bool HasComments { get; internal set; }
	public bool HasChildren { get; internal set; }
}
