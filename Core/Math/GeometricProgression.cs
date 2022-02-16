using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NiTiS.Core.Math
{
    [DebuggerDisplay("Progression [{First}:*{Q}] {Get(1)},{Get(2)},{Get(3)}")]
    public class GeometricProgression : IProgression
    {
        public double First { get; set; }
        public double Q { get; private set; }
        public GeometricProgression(double first, double q)
        {
            First = first;
            Q = q;
        }
        public double Get(int index)
        {
            return First * System.Math.Pow(Q, index - 1);
        }
        public static double Get(int index, double first, double q)
        {
            return first * System.Math.Pow(q, index - 1);
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
            return (First * (System.Math.Pow(Q, endIndex) - 1)) / (Q - 1);
        }
        public static double Sum(int endIndex, double first, double q)
        {
            return (first * (System.Math.Pow(q, endIndex) - 1)) / (q - 1);
        }
        public IEnumerable<double> SumArray(int count)
        {
            //Starts from 1 element
            for (int i = 1; i <= count; ++i)
            {
                yield return Get(i);
            }
        }
        public IEnumerable<double> SumArray(int startIndex, int endIndex)
        {
            for(;startIndex <= endIndex;)
            {
                yield return Get(startIndex);
                startIndex++;
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
