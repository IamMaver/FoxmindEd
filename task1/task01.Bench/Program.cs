using BenchmarkDotNet.Running;
using System;

namespace task01.Bench
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<AnagramBenchmark>();
        }
    }
}