using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiTiS.Net.Arguments;
public interface IArgument
{
	/// <summary>
	/// Get argument
	/// </summary>
	/// <returns>"<c>argumentName</c>=<c>value</c>"</returns>
	public string Create();
}
