namespace NiTiS.IO.Format;

public interface IFormatReader<T>
{
	public T Read(byte[] data);
}
public interface IFormatWriter<T>
{
	public byte[] Write(T value);
}
