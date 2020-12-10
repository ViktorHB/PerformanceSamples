using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnyVsCount
{
    public class Program
    {
        public static List<int> List = new List<int>();

        static Program()
        {
            Random rnd = new Random();
            for (int i = 0; i < 1_000_000; i++)
            {
                var n = rnd.Next();
                List.Add(n);
            }
        }

        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Program>();
        }

        [Benchmark]
        public void Any()
        {
            var res = List.Any();
        }

        [Benchmark]
        public void Count()
        {
            var res = List.Count > 0;
        }
    }
}
