namespace NiTiS.IO;

public enum OpenType : byte
{
	New = 0,
	Create = 1,
	Open = 2,
	OpenOrCreate = 3,
	Truncate = 4,
	Append = 5,
}