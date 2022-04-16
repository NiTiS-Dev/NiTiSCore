using System;

namespace NiTiS.Math;

/// <summary>
/// Assembly of fast and unsafe method to convert data types
/// </summary>
public static unsafe class UnsafeConverter
{
	/// <summary>
	/// Convert 32 bytes from <see cref="float"/> to 32 bytes for <see cref="int"/>
	/// </summary>
	public static int ToInt32(Single single) => *(int*)&single;
	/// <summary>
	/// Convert 32 bytes from <see cref="int"/> to 32 bytes for <see cref="float"/>
	/// </summary>
	public static float ToSingle(Int32 int32) => *(float*)&int32;
}
