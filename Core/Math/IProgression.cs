using System;
using System.Collections.Generic;

namespace NiTiS.Core.Math
{
    public interface IProgression : IProgression<double>
    {

    }
    public interface IProgression<T>
    {
        T First { get; set; }
        T Get(int index);
        T Sum(int endIndex);
        IEnumerable<T> SumArray(int endIndex);
        IEnumerable<T> SumArray(Predicate<T> predicate);
    }
}
