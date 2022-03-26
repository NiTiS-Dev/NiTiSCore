namespace NiTiS.IO;

public sealed class StorageElementAlreadyExistsException : Exception
{
	public IStorageElement StorageElement { get; private set; }
	public StorageElementAlreadyExistsException(IStorageElement storageElement)
	{
		this.StorageElement = storageElement;
	}
	public override string Message => $"Storage element already exists by path {StorageElement.Path}";
}