using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.Core.Types
{
    public class GeometricProgression
    {
        public double First { get; private set; }
        public double Q { get; private set; }
        public GeometricProgression(double first, double q)
        {
            First = first;
            Q = q;
        }
        public double Get(int index)
        {
            return First * System.Math.Pow(Q, index);
        }
        public double this[int index]
        {
            get
            {
                return Get(index);
            }
        }
        public IEnumerable<double> SumArray(int endIndex)
        {
            for (int i = 0; i < endIndex; ++i)
            {
                yield return Get(i);
            }
        }
    }
}
