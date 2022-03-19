using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.PreviewFunctions;

/// <summary>
/// Object whose have free constructor
/// </summary>
/// <typeparam name="T">Recreationable type</typeparam>
public interface IRecreationable<out T>
{
    /// <summary>
    /// Free constructor
    /// </summary>
    public static abstract Func<T> Constructor { get; }
}
