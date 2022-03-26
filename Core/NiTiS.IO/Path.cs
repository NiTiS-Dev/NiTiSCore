namespace NiTiS.IO;

public static class Path
{
	public static string Combine(params string[] args) => SPath.Combine(args);
	public static char DirectorySeparator => SPath.DirectorySeparatorChar;
	public static char AltDirectorySeparator => SPath.AltDirectorySeparatorChar;
	public static char VolumeSeparator => SPath.VolumeSeparatorChar;
	public static char PathSeparator => SPath.PathSeparator;
	public static char[] InvalidPathChars => SPath.GetInvalidPathChars();
	public static char[] InvalidFileNameChars => SPath.GetInvalidFileNameChars();
}
