namespace NiTiS.IO;

public sealed class StorageElementNotExistsExeption : Exception
{
	public IStorageElement StorageElement { get; private set; }
	public StorageElementNotExistsExeption(IStorageElement storageElement)
	{
		this.StorageElement = storageElement;
	}
	public override string Message => $"Storage element not found by path {StorageElement.Path}";
}