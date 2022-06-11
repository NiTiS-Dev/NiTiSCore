using NiTiS.Booru.Nekos.APIv2;

namespace NiTiS.Tests.Console
{
	public static unsafe class Program
	{
		private static void Main()
		{
			Client client = new();
			ResourceResponse resource = client.RequestImage(Endpoints.SFW.Fox).Result;
			SC.WriteLine(resource);
		}
	}
}