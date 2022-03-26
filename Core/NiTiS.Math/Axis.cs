using System;

namespace NiTiS.Math;

[Flags]
public enum Axis : byte
{
	X = 1,
	Y = 2,
	Z = 4,
	W = 8,
	Q = 16,
	S = 32,
	All = X | Y | Z | W | Q | S,
}