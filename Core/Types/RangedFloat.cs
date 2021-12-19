using NiTiS.Core.Additions;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NiTiS.Core.Types
{
    [DebuggerDisplay("Float ({MinValue}~{Value}~{MaxValue})")]
    public struct RangedFloat : IRangedVar<float> , IRawable<string>
    {
        private float value;
        private float min, max;
        public float MaxValue => max;

        public float MinValue => min;

        public float Value => value;
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
        public override string ToString()
        {
            return $"{min}~{value}~{max}";
        }
        public string GetRaw()
        {
            return min +":"+ value +":"+ max;
        }

        public void Restore(string rawData)
        {
            try
            {
                float[] values = rawData.Split(':').ForEachElements((element) =>
                {
                    return Single.Parse(element);
                }).ToArray();
                min = values[0];
                value = values[1];
                max = values[2];
            }
            catch(Exception ex)
            {
                Global.logger?.Log(ex.Message);
            }
        }
    }
}
