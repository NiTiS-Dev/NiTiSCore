// The NiTiS-Dev licenses this file to you under the MIT license.
using System;

namespace NiTiS.Net;
public class WebServiceException : Exception
{
	public WebServiceException(Uri site, System.Net.HttpStatusCode code) : base($"{site} returned status code: {code}") { }
}
