namespace NiTiS.Booru.Gelbooru.Tags;

public class RatingTag : SearchTag
{
	private readonly TagAccess access;
	private readonly Rating rating;
	public RatingTag(Rating rating, TagAccess access)
	{
		this.rating = rating;
		this.access = access;
	}
	public override string ToString() => $"{(access == TagAccess.Exclude ? "-":"")}rating:{GetRating()}";
	private string GetRating() => rating switch
	{
		Rating.Explicit => "explicit",
		Rating.Questionable => "questionable",
		_ => "safe"
	};
}
