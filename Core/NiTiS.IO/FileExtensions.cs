using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiTiS.IO;

public static class FileExtensions
{
	public static IEnumerable<File> WithExtension(this IEnumerable<File> files, string fileExtension) => files.Where(f => f.Extension == fileExtension);
	public static IEnumerable<File> WhichExists(this IEnumerable<File> files) => files.Where(f => f.Exists);
}
