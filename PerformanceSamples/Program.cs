using BenchmarkDotNet.Running;

namespace PerformanceSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<MemoryBenchmarkerDemo>();
        }
    }
}
