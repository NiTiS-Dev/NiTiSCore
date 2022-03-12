using System.Linq;

namespace NiTiS.IO;

/// <summary>
/// Presentation of some directory
/// </summary>
[System.Diagnostics.DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed class Directory : IStorageElement
{
    private string path;
    /// <summary>
    /// Directory single constructor
    /// </summary>
    /// <param name="path">Path to some directory</param>
    /// <exception cref="ArgumentNullException"></exception>
    public Directory(string path)
    {
        if (path is null)
        {
            throw new ArgumentNullException(nameof(path));
        }
        this.path = path;
    }
    public string Path => path;
    public string Name => SPath.GetFileName(path);
    public DateTime CreationTime { get => SDir.GetCreationTime(path); set => SDir.SetCreationTime(path, value); }
    public DateTime LastAccessTime { get => SDir.GetLastAccessTime(path); set => SDir.SetLastAccessTime(path, value); }
    public DateTime CreationTimeUTC { get => SDir.GetLastWriteTimeUtc(path); set => SDir.SetCreationTimeUtc(path, value); }
    public DateTime LastAccessTimeUTC { get => SDir.GetLastAccessTimeUtc(path); set => SDir.SetLastAccessTime(path, value); }
    public bool Exists => SDir.Exists(path);
    /// <summary>
    /// Entry to directory by name (works like cd command)
    /// </summary>
    /// <param name="folder"></param>
    public void Enter(string folder)
    {
        path = SPath.Combine(path, folder);
    }
    /// <summary>
    /// Exit from directory
    /// </summary>
    /// <param name="level">Folder exit depth</param>
    public void Exit(int level = 1)
    {
        path = SPath.Combine( Separate().SkipLast(level).ToArray());
    }
    /// <summary>
    /// Returns path separated by folders
    /// </summary>
    public string[] Separate()
    {
        return path.Split(SPath.VolumeSeparatorChar, StringSplitOptions.None);
    }
    /// <summary>
    /// Get other folders from this directory
    /// </summary>
    /// <param name="selfInclude">Include this directory</param>
    /// <returns></returns>
    public Directory[] GetNearbyDirectories(bool selfInclude = false)
    {
        return SDir.GetDirectories(SDir.GetDirectoryRoot(path)).Where(s => selfInclude || s != path).Select(s => new Directory(s)).ToArray();
    }
    /// <summary>
    /// Get internal files
    /// </summary>
    public File[] GetFiles()
    {
        return SDir.GetFiles(path).Select(s => new File(s)).ToArray();
    }
    /// <summary>
    /// Create dictonary if not exists
    /// </summary>
    public void Create()
    {
        if (Exists) return;
        SDir.CreateDirectory(path);
    }
    /// <summary>
    /// Get internal directories
    /// </summary>
    public Directory[] GetDirectories()
    {
        return SDir.GetDirectories(path).Select(s => new Directory(s)).ToArray();
    }
    public void ThrowIfNotExists()
    {
        if (SDir.Exists(path)) throw new StorageElementNotExistsExeption(this);
    }

    public static Directory GetCurrentDirectory() => new Directory(SDir.GetCurrentDirectory());
    public static Directory GetEnviromentDirectory(Environment.SpecialFolder folder) => new Directory(Environment.GetFolderPath(folder));

    public override string ToString()
    {
        return $"\"{path}\" [{(Exists ? "E" : "NE")}]";
    }
    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}