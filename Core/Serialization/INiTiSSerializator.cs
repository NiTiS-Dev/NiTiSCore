namespace NiTiS.Core.Serialization;

public interface INiTiSSerializator<Z>
{
    public Z Serialize<T>(T item);
    public T Deserialize<T>(string tabs, T item = default);
}