using BenchmarkDotNet.Running;

namespace AsQueryableBenchmarks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmarks>();
        }

    }
}
