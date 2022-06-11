// The NiTiS-Dev licenses this file to you under the MIT license.
using System.Threading.Tasks;

namespace NiTiS.Booru.Nekos.APIv2;
public class Client : NekoAPI
{
	public Client() : base(new("https://nekos.life/api/v2"))
	{

	}
	public Task<ResourceResponse> RequestImage(Endpoint endpoint)
		=> GetJsonResponseAsync<ResourceResponse>(new(Base.OriginalString + "/img/" + endpoint.filter));
}
