// The NiTiS-Dev licenses this file to you under the MIT license.

namespace NiTiS.Booru.Nekos.APIv2;
public class ResourceResponse
{
	/// <summary>
	/// Link to image (must be null)
	/// </summary>
	[JsonName("url")]
	public string? SourceLink { get; set; }
	/// <summary>
	/// Message with exception (must be null)
	/// </summary>
	[JsonName("msg")]
	public string? ErrorMessage { get; set; }
}
