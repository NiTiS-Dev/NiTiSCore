namespace NiTiS.IO;

public interface IStorageElement
{
	/// <summary>
	/// Name of the element
	/// </summary>
	public string Name { get; }
	/// <summary>
	/// Return path to the object
	/// </summary>
	public string Path { get; }
	/// <summary>
	/// Return <see langword="true"/> when object exists
	/// </summary>
	public bool Exists { get; }
	/// <summary>
	/// Time when element is created
	/// </summary>
	public DateTime CreationTime { get; set; }
	/// <summary>
	/// Time when element is last accessible
	/// </summary>
	public DateTime LastAccessTime { get; set; }
	/// <summary>
	/// Time when element is created (UTC)
	/// </summary>
	public DateTime CreationTimeUTC { get; set; }
	/// <summary>
	/// Time when element is last accessible(UTC)
	/// </summary>
	public DateTime LastAccessTimeUTC { get; set; }
	/// <summary>
	/// Throws <seealso cref="NiTiS.IO.StorageElementNotExistsExeption"/> when file not exists
	/// </summary>
	public void ThrowIfNotExists();
}