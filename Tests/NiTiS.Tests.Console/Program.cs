using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using NiTiS.Math.Experemental.Vectors;
using NiTiS.Math.Vectors;

namespace NiTiS.Tests.Console
{
    public class Program
    {
        private static unsafe void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Test>();
        }
    }
    public class Test
    {
        [Benchmark]
        public Vector2D DefaultVectorPlus()
        {
            Vector2D left = new(0, 5);
            Vector2D right = new(7, -12);
            return left + right;
        }
        [Benchmark]
        public Vector2D<float> GenericVectorPlus()
        {
            Vector2D<float> left = new(0, 5);
            Vector2D<float> right = new(7, -12);
            return left + right;
        }
    }
}