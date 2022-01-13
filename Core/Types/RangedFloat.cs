using System;
using System.Diagnostics;

namespace NiTiS.Core.Types
{
    [DebuggerDisplay("Float ({MinValue}~{Value}~{MaxValue})")]
    public struct RangedFloat : IRangedVar<float>, IEquatable<RangedFloat>, IEquatable<float>
    {
        private float value;
        private float min;
        private float max;
        public float MaxValue => max;
        public float MinValue => min;
        public float Value => value;
        public void SetValue(float value)
        {
            if (value < min)
            {
                this.value = min;
            }
            else if (value > max)
            {
                this.value = max;
            }
            else
            {
                this.value = value;
            }
        }

        public static RangedFloat operator +(RangedFloat left, IRangedVar<float> right)
        {
            left.SetValue(left.Value + right.Value);
            return left;
        }
        public static RangedFloat operator +(RangedFloat left, float right)
        {
            left.SetValue(left.Value + right);
            return left;
        }
        public static RangedFloat operator -(RangedFloat left, IRangedVar<float> right)
        {
            left.SetValue(left.Value - right.Value);
            return left;
        }
        public static RangedFloat operator -(RangedFloat left, float right)
        {
            left.SetValue(left.Value - right);
            return left;
        }
        public static RangedFloat operator /(RangedFloat left, IRangedVar<float> right)
        {
            left.SetValue(left.Value / right.Value);
            return left;
        }
        public static RangedFloat operator /(RangedFloat left, float right)
        {
            left.SetValue(left.Value / right);
            return left;
        }
        public static RangedFloat operator *(RangedFloat left, IRangedVar<float> right)
        {
            left.SetValue(left.Value * right.Value);
            return left;
        }
        public static RangedFloat operator *(RangedFloat left, float right)
        {
            left.SetValue(left.Value * right);
            return left;
        }
        public static bool operator ==(RangedFloat left, float right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(RangedFloat left, float right)
        {
            return !left.Equals(right);
        }

        public static bool operator ==(RangedFloat left, RangedFloat right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(RangedFloat left, RangedFloat right)
        {
            return !left.Equals(right);
        }

        public RangedFloat(float value, float min = 0, float max = 10)
        {
            this.value = value;
            this.min = min;
            this.max = max;
        }
        public RangedFloat(int value, int min = 0, int max = 10)
        {
            this.value = value;
            this.min = min;
            this.max = max;
        }
        public override string ToString()
        {
            return $"{min}~{value}~{max}";
        }

        public override bool Equals(object obj)
        {
            return obj is RangedFloat @float && Equals(@float);
        }

        public bool Equals(RangedFloat other)
        {
            return value == other.value &&
                   min == other.min &&
                   max == other.max;
        }

        public override int GetHashCode()
        {
            int hashCode = -281913742;
            hashCode = hashCode * -1521134295 + value.GetHashCode();
            hashCode = hashCode * -1521134295 + min.GetHashCode();
            hashCode = hashCode * -1521134295 + max.GetHashCode();
            return hashCode;
        }

        public bool Equals(float other)
        {
            return value.Equals(other);
        }
    }
}
