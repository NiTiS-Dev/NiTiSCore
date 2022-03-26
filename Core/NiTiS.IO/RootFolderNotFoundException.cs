namespace NiTiS.IO;

public sealed class RootFolderNotFoundException : Exception
{
	public IStorageElement StorageElement { get; private set; }
	public RootFolderNotFoundException(IStorageElement storageElement)
	{
		this.StorageElement = storageElement;
	}
	public override string Message => $"Root folder not found {StorageElement}";
}
