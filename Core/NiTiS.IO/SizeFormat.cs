using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiTiS.IO;
public enum SizeFormat : byte
{
	/// <summary>
	/// 1 byte
	/// </summary>
	Byte = 0,

	//Decimal types
	/// <summary>
	/// 1000 bytes
	/// </summary>
	Kilobyte = 1,
	/// <summary>
	/// 1000^2 bytes
	/// </summary>
	Megabyte = 2,
	/// <summary>
	/// 1000^3 bytes
	/// </summary>
	Gigabyte = 3,
	/// <summary>
	/// 1000^4 bytes
	/// </summary>
	Terabyte = 4,

	//Standart types
	/// <summary>
	/// 1024 bytes
	/// </summary>
	Kibibyte = 21,
	/// <summary>
	/// 1024^2 bytes
	/// </summary>
	Mebibyte = 22,
	/// <summary>
	/// 1024^3 bytes
	/// </summary>
	Gibibyte = 23,
	/// <summary>
	/// 1024^4 bytes
	/// </summary>
	Tebibyte = 24,

	/// <summary>
	/// 1/8 byte
	/// </summary>
	Bit = 200,
}