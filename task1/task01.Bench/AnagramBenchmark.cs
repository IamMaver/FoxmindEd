using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace task01.Bench
{
    [MemoryDiagnoser]
    [RankColumn]
    public class AnagramBenchmark
    {
        private const string STRING_TO_REVERSE1 = "Str td!@#$%^&a1bc№!()bn:: dsss-v";
   
        private readonly Anagram _anagram = new Anagram();

        [Benchmark]
        public void BenchReverse1st()
        {
            string result = _anagram.Reverse(STRING_TO_REVERSE1);
        }

        [Benchmark]
        public void BenchReverse2nd()
        {
            string result = _anagram.Reverse2nd(STRING_TO_REVERSE1);
        }
    }
}
