using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;

namespace ValueTypeVsReferencesType
{
    /// <summary>
    /// Sample application to show the performance difference between value types and reference types:
    /// We have 3 different types (1 reference type, 1 value type without proper equals method and 1 value type with proper equal method
    /// In the benchmarkdotnet test methods we create a list from these type, add 1mio items to the lists and search for an item that is not in the list
    /// </summary>
    [MemoryDiagnoser]
    public class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Program>();
        }

        /// <summary>
        /// Tests for class
        /// </summary>
        [Benchmark]
        public void ManyClasses()
        {
            Random rnd = new Random();
            var list = new List<PointClass>();

            for (int i = 0; i < 1_000_000; i++)
            {
                list.Add(new PointClass() { X = rnd.Next(), Y = rnd.Next() });
            }

            list.Contains(new PointClass { X = -1, Y = -1 }); //won't be in the the list, since this is a new reference
        }

        /// <summary>
        /// Tests for strucrure without overloads
        /// </summary>
        [Benchmark]
        public void ManyStructs_NoOverLoad()
        {
            Random rnd = new Random();
            var list = new List<PointStructNoOverLoad>();

            for (int i = 0; i < 1_000_000; i++)
            {
                list.Add(new PointStructNoOverLoad() { x = rnd.Next(), y = rnd.Next() });
            }

            list.Contains(new PointStructNoOverLoad { x = -1, y = -1 }); //won't be in the list, since rnd.Next() only returns non-negative numbers
        }

        /// <summary>
        /// Tests for strucrure with overloads
        /// </summary>
        [Benchmark]
        public void ManyStructs_ProperImplementation()
        {
            Random rnd = new Random();
            var list = new List<PointStructProperImplementation>();

            for (int i = 0; i < 1_000_000; i++)
            {
                list.Add(new PointStructProperImplementation() { x = rnd.Next(), y = rnd.Next() });
            }

            list.Contains(new PointStructProperImplementation { x = -1, y = -1 }); //won't be in the list, since rnd.Next() only returns non-negative numbers
        }
    }
}