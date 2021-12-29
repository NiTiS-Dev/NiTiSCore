using NiTiS.Core.Additions;
using System;
using System.Diagnostics;

namespace NiTiS.Core.Types
{
    [DebuggerDisplay("Int ({MinValue}~{Value}~{MaxValue})")]
    public struct RangedInt : IRangedVar<int>
    {
        private int value;
        private int min, max;
        public int MaxValue => max;
        public int MinValue => min;
        public int Value => value;
        public void SetValue(int value)
        {
            int futureValue = this.value + value;
            if (futureValue < min)
            {
                this.value = min;
            }
            else if (futureValue > max)
            {
                this.value = max;
            }
            else
            {
                this.value = futureValue;
            }
        }

        public RangedInt(int value, int min = 0, int max = 10)
        {
            this.value = value;
            this.min = min;
            this.max = max;
        }
        public override string ToString()
        {
            return $"{min}~{value}~{max}";
        }
    }
}
