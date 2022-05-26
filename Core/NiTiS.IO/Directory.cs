using System.Linq;

namespace NiTiS.IO;

/// <summary>
/// Presentation of some directory
/// </summary>
[System.Diagnostics.DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed class Directory : Path, IStorageElement
{
	public Directory(params string[] path) : base(Combine(path)) { }
	public Directory(string path) : base(path) { }
	public Directory(Directory directory, string directoryName) : base(Combine(directory.Path, directoryName)) { }
	public Directory(File file) : base(file.Parent.path) { }
	public string Path => this.path;
	public string Name => SPath.GetFileName(this.path);
	/// <summary>
	/// Directory where located this directory
	/// </summary>
	/// <exception cref="NiTiS.IO.RootFolderNotFoundException"></exception>
	public Directory Parent
	{
		get
		{
			System.IO.DirectoryInfo? info = null;
			try
			{
				info = SDir.GetParent(this.path);
			}
			catch (System.IO.DirectoryNotFoundException) { }
			return info is null ? throw new RootFolderNotFoundException(this) : (new(info.FullName));
		}
	}
	public DateTime CreationTime { get => SDir.GetCreationTime(this.path); set => SDir.SetCreationTime(this.path, value); }
	public DateTime LastAccessTime { get => SDir.GetLastAccessTime(this.path); set => SDir.SetLastAccessTime(this.path, value); }
	public DateTime CreationTimeUTC { get => SDir.GetLastWriteTimeUtc(this.path); set => SDir.SetCreationTimeUtc(this.path, value); }
	public DateTime LastAccessTimeUTC { get => SDir.GetLastAccessTimeUtc(this.path); set => SDir.SetLastAccessTime(this.path, value); }
	public bool Exists => SDir.Exists(path);
	/// <summary>
	/// Renaming the directory
	/// </summary>
	/// <param name="newName">New name</param>
	/// <param name="overwrite">Should I delete the directory with the same name</param>
	public void Rename(string newName, bool overwrite = false)
	{
		ThrowIfNotExists();
		Directory newLocation = new(Parent.Path, newName);
		if (overwrite)
		{
			newLocation.Delete();
		}
		this.path = newLocation.path;
	}
	/// <summary>
	/// Returns path separated by folders
	/// </summary>
	public String[] Separate()
	{
#if NET48
		return path.Split(new char[] { SPath.DirectorySeparatorChar }, StringSplitOptions.None);
#else
		return this.path.Split(SPath.DirectorySeparatorChar, StringSplitOptions.None);
#endif
	}
	/// <summary>
	/// Get other folders from this directory
	/// </summary>
	/// <param name="selfInclude">Include this directory</param>
	/// <returns></returns>
	public Directory[] GetNearbyDirectories(bool selfInclude = false)
	{
		return SDir.GetDirectories(SDir.GetDirectoryRoot(this.path)).Where(s => selfInclude || s != this.path).Select(s => new Directory(s)).ToArray();
	}
	/// <summary>
	/// Get internal files
	/// </summary>
	public File[] GetFiles()
	{
		return SDir.GetFiles(this.path).Select(s => new File(s)).ToArray();
	}
	/// <summary>
	/// Create dictonary if not exists
	/// </summary>
	public void Create()
	{
		if (Exists) return;
		SDir.CreateDirectory(this.path);
	}
	/// <summary>
	/// Get internal directories
	/// </summary>
	public Directory[] GetDirectories()
	{
		return SDir.GetDirectories(this.path).Select(s => new Directory(s)).ToArray();
	}
	public void ThrowIfNotExists()
	{
		if (!Exists) throw new StorageElementNotExistsExeption(this);
	}
	/// <summary>
	/// Delete current file from storage
	/// </summary>
	public void Delete(bool recursive) => SDir.Delete(path, recursive);
	/// <summary>
	/// Delete current file from storage
	/// </summary>
	public void Delete() => SDir.Delete(path);

	public static Directory GetCurrentDirectory() => new Directory(SDir.GetCurrentDirectory());
	public static Directory GetEnviromentDirectory(Environment.SpecialFolder folder) => new Directory(Environment.GetFolderPath(folder));

	public override string ToString()
	{
		return $"\"{this.path}\" [{(Exists ? "E" : "NE")}]";
	}
	private string GetDebuggerDisplay() => ToString();
	/// <summary>
	/// Returns <see langword="true"/> when all directories exists and notnull
	/// </summary>
	public static bool AllExists(params Directory[] directories)
	{
		foreach (Directory? directory in directories)
		{
			if (!(directory?.Exists ?? false)) return false;
		}
		return true;
	}
}