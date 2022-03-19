namespace NiTiS.PreviewFunctions;

/// <summary>
/// Representation of singleton
/// </summary>
/// <typeparam name="T">Singleton type</typeparam>
public interface ISingleton<out T>
{
    /// <summary>
    /// Instance
    /// </summary>
    public abstract static T Instance { get; }
    /// <summary>
    /// Returns <see langword="true"/> when instancieded, otherwise <see langword="false"/>
    /// </summary>
    public abstract static bool IsInstancieded { get; }
}
