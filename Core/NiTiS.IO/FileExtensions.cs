using System.Collections.Generic;
using System.Linq;

namespace NiTiS.IO;

public static class FileExtensions
{
	public static IEnumerable<File> WithExtension(this IEnumerable<File> files, string fileExtension) => fileExtension[0] == '.' ? files.Where(f => f.Extension == fileExtension) : throw new ArgumentException("Extension must be starts with \".\"");
	public static IEnumerable<File> WhichExists(this IEnumerable<File> files) => files.Where(f => f.Exists);
}
