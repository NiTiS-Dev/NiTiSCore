using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.Core.Types
{
    public class ArithmeticProgression
    {
        public double First { get; private set; }
        public double D { get; private set; }
        public ArithmeticProgression(double first, double d)
        {
            First = first;
            D = d;
        }
        public double Get(int index)
        {
            return First + (D * (index -1));
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
            for(int i = 0; i < endIndex;)
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
            }while(predicate(Get(i)));
        }
    }
}
