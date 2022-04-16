namespace NiTiS.IO.Format;

public interface IFormatReader<out T>
{
	public T Read(byte[] data);
}
public interface IFormatWriter<in T>
{
	public byte[] Write(T value);
}
