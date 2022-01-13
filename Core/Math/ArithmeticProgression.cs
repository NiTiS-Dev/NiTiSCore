using NiTiS.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NiTiS.Core.Math
{
    [DebuggerDisplay("Progression [{First}:{D}] {Get(1)},{Get(2)},{Get(3)}")]
    [NiTiSCoreTypeInfo("1.4.0.0", "2.0.0.0")]
    public class ArithmeticProgression : IProgression
    {
        public double First { get; set; }
        public double D { get; private set; }
        public ArithmeticProgression(double first, double d)
        {
            First = first;
            D = d;
        }
        public double Get(int index)
        {
            return First + (D * (index - 1));
        }
        public static double Get(int index, double first, double d)
        {
            return first + (d * (index - 1));
        }
        public double this[int index]
        {
            get
            {
                return Get(index);
            }
        }
        public double Sum(int endIndex)
        {
            return First + D * (endIndex - 1);  
        }
        public static double Sum(int endIndex, double first, double d)
        {
            return first + d * (endIndex - 1);
        }
        public IEnumerable<double> SumArray(int endIndex)
        {
            for (int i = 0; i < endIndex;)
            {
                i++;
                yield return Get(i);
            }
        }
        public IEnumerable<double> SumArray(Predicate<double> predicate)
        {
            int i = 0;
            do
            {
                i++;
                yield return Get(i);
            } while (predicate(Get(i)));
        }
    }
}
