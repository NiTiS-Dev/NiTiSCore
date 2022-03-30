using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace NiTiS.Booru;

public abstract class BooruSite
{
	protected readonly HttpClient client;
	public BooruSite(HttpClient client)
	{
		this.client = client;
	}
	public Task<XmlDocument> AsyncGetXml(string attributes) => Task.Run(() =>
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(AsyncGetText(attributes).Result);
		return xmlDocument;
	} );
	public Task<byte[]> AsyncGetBytes(string attributes) => client.GetByteArrayAsync(attributes);
	public Task<string> AsyncGetText(string attributes) => client.GetStringAsync(attributes);
	public Task<Stream> AsyncGetStream(string attributes) => client.GetStreamAsync(attributes);
}
