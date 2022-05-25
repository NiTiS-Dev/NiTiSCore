namespace NiTiS.IO;

/// <summary>
/// Provides methods for action with existing file
/// </summary>
[System.Diagnostics.DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed class File : Path, IStorageElement
{
	/// <summary>
	/// File constructor
	/// </summary>
	/// <param name="path">Path to some file</param>
	/// <exception cref="ArgumentNullException"></exception>
	public File(params string[] path) : base(Combine(path))
	{
		if (path is null)
		{
			throw new ArgumentNullException(nameof(path));
		}
	}
	/// <summary>
	/// File constructor
	/// </summary>
	/// <param name="fileName">Name of file</param>
	/// <param name="parent">Directory of file</param>
	/// <exception cref="ArgumentNullException"></exception>
	public File(Directory parent, string fileName) : base(Combine(parent.Path, fileName))
	{
		if (parent is null)
		{
			throw new ArgumentNullException(nameof(path));
		}
		if (fileName is null)
		{
			throw new ArgumentNullException(nameof(fileName));
		}
	}
	public string Path => path;
	public MemorySize Size => Exists ? new( new System.IO.FileInfo(path).Length ) : MemorySize.Zero;
	public string Name => SPath.GetFileName(path);
	/// <summary>
	/// Name of the element (extension exclude)
	/// </summary>
	public string NameWithoutExtension => SPath.GetFileNameWithoutExtension(path);
	/// <summary>
	/// Extension of the file (including the period ".")
	/// </summary>
	public string Extension => SPath.GetExtension(path);
	/// <summary>
	/// Directory where located this file
	/// </summary>
	/// <exception cref="RootFolderNotFoundException"></exception>
	public Directory Parent
	{
		get
		{
			System.IO.DirectoryInfo? info = null;
			try
			{
				info = SDir.GetParent(path);
			}
			catch (System.IO.DirectoryNotFoundException) { }
			return info is null ? throw new RootFolderNotFoundException(this) : (new(info.FullName));
		}
	}
	public DateTime CreationTime { get => SDir.GetCreationTime(path); set => SDir.SetCreationTime(path, value); }
	public DateTime LastAccessTime { get => SDir.GetLastAccessTime(path); set => SDir.SetLastAccessTime(path, value); }
	public DateTime CreationTimeUTC { get => SDir.GetLastWriteTimeUtc(path); set => SDir.SetCreationTimeUtc(path, value); }
	public DateTime LastAccessTimeUTC { get => SDir.GetLastAccessTimeUtc(path); set => SDir.SetLastAccessTime(path, value); }
	public bool Exists => SFile.Exists(path);
	/// <summary>
	/// Renaming the file
	/// </summary>
	/// <remarks>
	/// if you want to rename file to other location, use <see cref="MoveTo(File, Boolean)"/> method
	/// </remarks>
	/// <param name="newName">New name</param>
	/// <param name="overwrite">Should I delete the file with the same name</param>
	public void Rename(string newName, bool overwrite = false)
	{
		ThrowIfNotExists();
		File newLocation = new(Parent.Path, newName);
		if (overwrite)
		{
			newLocation.Delete();
		}
		this.path = newLocation.path;
	}
	/// <summary>
	/// Create file if not exists
	/// </summary>
	public void Create(bool createSubDirectory = false)
	{
		if (createSubDirectory && !Parent.Exists)
		{
			Parent.Create();
		}
		if (Exists) return;
		SFile.Create(path).Dispose();
	}
	/// <summary>
	/// Returns the stream to read the file
	/// </summary>
	/// <exception cref="System.IO.PathTooLongException"></exception>
	/// <exception cref="UnauthorizedAccessException"></exception>
	/// <exception cref="NotSupportedException"></exception>
	/// <exception cref="System.IO.IOException"></exception>
	public System.IO.FileStream OpenForRead() => SFile.OpenRead(path);
	/// <summary>
	/// Returns the stream to write the file
	/// </summary>
	/// <exception cref="System.IO.PathTooLongException"></exception>
	/// <exception cref="UnauthorizedAccessException"></exception>
	/// <exception cref="NotSupportedException"></exception>
	public System.IO.FileStream OpenForWrite() => SFile.OpenWrite(path);
	/// <summary>
	/// Returns the stream by options
	/// </summary>
	/// <param name="openType">The type to open (or create) the element </param>
	/// <param name="access">Access level of the opened element </param>
	/// <returns></returns>
	/// <exception cref="StorageElementAlreadyExistsException"></exception>
	/// <exception cref="ArgumentException"></exception>
	public System.IO.FileStream Open(OpenType openType = OpenType.OpenOrCreate, FileAccess access = FileAccess.Full)
	{
		switch (openType)
		{
			case OpenType.Open:
				{
					return SFile.Open(path, System.IO.FileMode.Open, (System.IO.FileAccess)(byte)access);
				}
			case OpenType.Create:
				{
					return SFile.Create(path);
				}
			case OpenType.New:
				{
					return Exists ? throw new StorageElementAlreadyExistsException(this) : SFile.Create(path);
				}
			case OpenType.OpenOrCreate:
				{
					return Exists ? SFile.Open(path, System.IO.FileMode.Open, (System.IO.FileAccess)(byte)access) : SFile.Create(path);
				}
			case OpenType.Append:
				{
					return SFile.Open(path, System.IO.FileMode.Append);
				}
			case OpenType.Truncate:
				{
					return SFile.Open(path, System.IO.FileMode.Truncate);
				}
			default:
				{
					throw new ArgumentException($"Invalid falue of {openType} parameter");
				}
		}
	}
	/// <summary>
	/// Copies data from a file to another file
	/// (if the file does not exist, it will create a new one)
	/// </summary>
	/// <param name="path">The path to which we copy the data </param>
	/// <param name="overwrite">Whether to overwrite the file (if it exists) </param>
	/// <exception cref="ArgumentNullException"></exception>
	public void CopyTo(string path, bool overwrite = false) => CopyTo(new File(path), overwrite);
	/// <summary>
	/// Copies data from a file to another file
	/// (if the file does not exist, it will create a new one)
	/// </summary>
	/// <param name="copyTo">The file to which we copy the data </param>
	/// <param name="overwrite">Whether to overwrite the file (if it exists) </param>
	/// <exception cref="ArgumentNullException"></exception>
	public void CopyTo(File copyTo, bool overwrite = false)
	{
		if (copyTo is null)
		{
			throw new ArgumentNullException(nameof(copyTo));
		}
		this.ThrowIfNotExists();
		SFile.Copy(Path, copyTo.Path, overwrite);
	}
	/// <summary>
	/// Move file to other space
	/// </summary>
	/// <param name="path">The path to move</param>
	/// <param name="overwrite">Whether to overwrite the file (if it exists)</param>
	public void MoveTo(string path, bool overwrite = true) => MoveTo(new File(path), overwrite);
	/// <summary>
	/// Move file to other space
	/// </summary>
	/// <param name="moveTo">Position to move</param>
	/// <param name="overwrite">Whether to overwrite the file (if it exists)</param>
	public void MoveTo(File moveTo, bool overwrite = true)
	{
		CopyTo(moveTo, overwrite);
		Delete();
	}
	/// <summary>
	/// Create backup file from existing file
	/// </summary>
	/// <param name="path">Path to backup file</param>
	/// <param name="copy">Make copy or just create new file</param>
	public File CreateBackupFile(string? path = null, bool copy = true)
	{
		(this as IStorageElement).ThrowIfNotExists();
		path ??= this.path + ".bac";
		File bac = new(path);
		if (copy)
		{
			using System.IO.FileStream stream = SFile.Create(bac.Path);
			byte[] arr = SFile.ReadAllBytes(Path);
			stream.Write(arr, 0, arr.Length);
		}
		return bac;
	}
	/// <summary>
	/// Read a file as byte array
	/// </summary>
	public byte[] ReadBytes()
	{
		(this as IStorageElement).ThrowIfNotExists();
		return SFile.ReadAllBytes(path);
	}
	/// <summary>
	/// Read a file as string
	/// </summary>
	public string ReadText()
	{
		(this as IStorageElement).ThrowIfNotExists();
		return SFile.ReadAllText(path);
	}
	/// <summary>
	/// Write byte array to file
	/// </summary>
	public void WriteBytes(byte[] bytes)
	{
		(this as IStorageElement).ThrowIfNotExists();
		SFile.WriteAllBytes(path, bytes);
	}
	/// <summary>
	/// Write string to file
	/// </summary>
	public void WriteText(string value)
	{
		(this as IStorageElement).ThrowIfNotExists();
		SFile.WriteAllText(path, value);
	}
	/// <summary>
	/// Swap files values
	/// </summary>
	/// <param name="destinationFile">File for replace</param>
	/// <param name="destinationBackupFile">Backup for destination file</param>
	public void Replace(File destinationFile, File? destinationBackupFile)
	{
		this.ThrowIfNotExists();
		destinationFile.ThrowIfNotExists();
		destinationBackupFile ??= destinationFile.CreateBackupFile();
		destinationFile.CopyTo(destinationBackupFile);
		this.CopyTo(destinationFile);
		destinationBackupFile.CopyTo(this);
		destinationBackupFile.Delete();
		this.path = destinationBackupFile.path;
	}
	/// <summary>
	/// Delete current file from storage
	/// </summary>
	public void Delete() => SFile.Delete(path);

#if NITIS_IO_ASYNC
	/// <summary>
	/// Copies data from a file to another file asynchronously
	/// (if the file does not exist, it will create a new one)
	/// </summary>
	/// <param name="path">The path to which we copy the data </param>
	/// <param name="overwrite">Whether to overwrite the file (if it exists) </param>
	/// <exception cref="ArgumentNullException"></exception>
	public Task CopyToAsync(string path, bool overwrite = false) => CopyToAsync(new File(path), overwrite);
	/// <summary>
	/// Copies data from a file to another file asynchronously
	/// (if the file does not exist, it will create a new one)
	/// </summary>
	/// <param name="copyTo">The file to which we copy the data </param>
	/// <param name="overwrite">Whether to overwrite the file (if it exists) </param>
	/// <exception cref="ArgumentNullException"></exception>
	public async Task CopyToAsync(File copyTo, bool overwrite = false)
	{
		if (copyTo is null)
		{
			throw new ArgumentNullException(nameof(copyTo));
		}
		this.ThrowIfNotExists();
		byte[] arr = await SFile.ReadAllBytesAsync(path);
		if (overwrite)
		{
			await SFile.Create(copyTo.path).DisposeAsync();
		}
		using SFileStream to = SFile.OpenRead(copyTo.path);
		await to.WriteAsync(arr);
	}
	/// <summary>
	/// Move file to other space asynchronously
	/// </summary>
	/// <param name="path">The path to move</param>
	/// <param name="overwrite">Whether to overwrite the file (if it exists)</param>
	public Task MoveToAsync(string path, bool overwrite = true) => MoveToAsync(new File(path), overwrite);
	/// <summary>
	/// Move file to other space asynchronously
	/// </summary>
	/// <param name="moveTo">Position to move</param>
	/// <param name="overwrite">Whether to overwrite the file (if it exists)</param>
	public async Task MoveToAsync(File moveTo, bool overwrite = true)
	{
		await CopyToAsync(moveTo, overwrite);
		await DeleteAsync();
	}
	/// <summary>
	/// Create backup file from existing file asynchronously
	/// </summary>
	/// <param name="path">Path to backup file</param>
	public async Task<File> CreateBackupFileAsync(string? path = null)
	{
		(this as IStorageElement).ThrowIfNotExists();
		path ??= this.path + ".bac";
		File bac = new(path);
		using System.IO.FileStream stream = SFile.Create(bac.Path);
		byte[] arr = await SFile.ReadAllBytesAsync(Path);
		await stream.WriteAsync(arr, 0, arr.Length);
		return bac;
	}
	/// <summary>
	/// Read a file as byte array asynchronously
	/// </summary>
	public Task<byte[]> ReadBytesAsync(CancellationToken cancellationToken = default)
	{
		(this as IStorageElement).ThrowIfNotExists();
		return SFile.ReadAllBytesAsync(path, cancellationToken);
	}
	/// <summary>
	/// Read a file as string asynchronously
	/// </summary>
	public Task<string> ReadTextAsync(CancellationToken cancellationToken = default)
	{
		(this as IStorageElement).ThrowIfNotExists();
		return SFile.ReadAllTextAsync(path, cancellationToken);
	}
	/// <summary>
	/// Write byte array to file asynchronously
	/// </summary>
	public Task WriteBytesAsync(byte[] bytes, CancellationToken cancellationToken = default)
	{
		(this as IStorageElement).ThrowIfNotExists();
		return SFile.WriteAllBytesAsync(path, bytes, cancellationToken);
	}
	/// <summary>
	/// Write string to file asynchronously
	/// </summary>
	public Task WriteTextAsync(string value, CancellationToken cancellationToken = default)
	{
		(this as IStorageElement).ThrowIfNotExists();
		return SFile.WriteAllTextAsync(path, value, cancellationToken);
	}
	/// <summary>
	/// Swap files values asynchronously
	/// </summary>
	/// <param name="destinationFile">File for replace</param>
	/// <param name="destinationBackupFile">Backup for destination file</param>
	public async Task ReplaceAsync(File destinationFile, File? destinationBackupFile)
	{
		this.ThrowIfNotExists();
		destinationFile.ThrowIfNotExists();
		destinationBackupFile ??= await destinationFile.CreateBackupFileAsync();
		await destinationFile.CopyToAsync(destinationBackupFile);
		await this.CopyToAsync(destinationFile);
		await destinationBackupFile.CopyToAsync(this);
		await destinationBackupFile.DeleteAsync();
	}
	/// <summary>
	/// Delete current file from storage asynchronously
	/// </summary>
	public async Task DeleteAsync() => await Task.Run(() => SFile.Delete(path));
#endif
	public void ThrowIfNotExists()
	{
		if (!Exists) throw new StorageElementNotExistsExeption(this);
	}

	public override string ToString()
	{
		return $"\"{path}\" [{(Exists ? "E" : "NE")}]";
	}
	private string GetDebuggerDisplay()
	{
		return ToString();
	}
	/// <summary>
	/// Returns <see langword="true"/> when all files exists and notnull
	/// </summary>
	public static bool AllExists(params File?[] files)
	{
		foreach(File? file in files)
		{
			if (!(file?.Exists ?? false)) return false;
		}
		return true;
	}
}