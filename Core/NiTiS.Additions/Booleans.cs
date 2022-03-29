namespace NiTiS.Additions;

public static class Booleans
{
	public static bool Invert(this bool self, bool invert) => invert? !self : self;
}
