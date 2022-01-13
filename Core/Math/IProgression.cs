using NiTiS.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.Core.Math
{
    [NiTiSCoreTypeInfo("1.6.0.0", "2.0.0.0")]
    public interface IProgression : IProgression<double>
    {

    }
    [NiTiSCoreTypeInfo("1.6.0.0", "2.0.0.0")]
    public interface IProgression<T>
    {
        T First { get; set; }
        T Get(int index);
        T Sum(int endIndex);
        IEnumerable<T> SumArray(int endIndex);
        IEnumerable<T> SumArray(Predicate<T> predicate);
    }
}
