using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Buffers;
using System.Diagnostics;

namespace Array.ArrayPool
{
    /// <summary>
    /// A sample application that calls a method 1000 times 
    /// which uses the ArrayPool. In project Array.NoPool we compare this method 
    /// to a similar method from project Array.NoPool that uses manual array allocation
    /// instead of pooling arrays with  ArrayPool
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Program>();
        }

        [Benchmark]
        public void ArrayPool()
        {
            for (int i = 0; i < 1000; i++)
            {
                var arr = ArrayPool<int>.Shared.Rent(256 * 1024);
                Debug.WriteLine(arr[0].ToString());
                //use arr.
                ArrayPool<int>.Shared.Return(arr);
            }
        }

        [Benchmark]
        public void NoPool()
        {
            for (int i = 0; i < 1000; i++)
            {
                var arr = new int[256 * 1024];
                Debug.WriteLine(arr[0].ToString());
            }
        }
    }
}
