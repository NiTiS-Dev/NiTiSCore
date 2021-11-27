using System.Diagnostics;

namespace NiTiS.Core.Variables
{
    [DebuggerDisplay("Float ({MinValue()}~{Value()}~{MaxValue()})")]
    public struct RangedFloat : IRangedVar<float>
    {
        private float value;
        private float min, max;
        public float MaxValue() => max;

        public float MinValue() => min;

        public float Value() => value;
        public void SetValue(float value)
        {
            float futureValue = this.value + value;
            if(futureValue < min)
            {
                this.value = min;
            }
            else if(futureValue > max)
            {
                this.value = max;
            }
            else
            {
                this.value = futureValue;
            }
        }
        public RangedFloat(float value, float min = 0, float max = 10)
        {
            this.value = value;
            this.min = min;
            this.max = max;
        }
    }
}
