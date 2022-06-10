// The NiTiS-Dev licenses this file to you under the MIT license.

using NiTiS.Net;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NiTiS.Booru.Nekos;
public abstract class NekoAPI
{
	public readonly Uri Base;
	
	internal NekoAPI(Uri @base)
	{
		Base = @base;
	}
	protected static async Task<T> GetJsonResponseAsync<T>(Uri destination)
	{
		return Deserialize<T>(await GetRawResponseAsync(destination));
	}
	protected static async Task<string> GetRawResponseAsync(Uri destination)
	{
		using HttpClient client = new();
		HttpRequestMessage request = new(HttpMethod.Get, destination);
		HttpResponseMessage? response = await client.SendAsync(request);

		if (!response.IsSuccessStatusCode)
		{
#if DEBUG
			Console.WriteLine(new WebServiceException(destination, response.StatusCode).Message);
#endif
			return String.Empty;
		}

		return await response.Content.ReadAsStringAsync();
	}
}
