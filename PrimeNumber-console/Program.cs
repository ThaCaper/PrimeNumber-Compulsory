using System;
using System.Collections.Generic;
using System.Diagnostics;
using PrimeNumber_Compulsory;

namespace PrimeNumber_console
{
    class Program
    {
        private static PrimeGenerator primeNumber = new PrimeGenerator();
        private static long a = 0;
        private static long b = 1000000;
        private static List<long> primes;
        static void Main(string[] args)
        {
            Console.WriteLine("Test");

            // Console.WriteLine(GetPrimeNumbers(a, b).Count);
            MeasureTime(() => GetPrimeNumbers(a, b));
            MeasureTime(() => GetPrimeNumberParallel(a, b));

            //primes.Sort();
            //foreach (var item in primes)
            //{
            //    Console.WriteLine(item);
            //}
        }

        private static void GetPrimeNumbers(long primeA, long primeB)
        {
            primes = new List<long>(primeNumber.GetPrimesSequential(primeA, primeB));
        }

        private static void GetPrimeNumberParallel(long primeA, long primeB)
        {
            primes = new List<long>(primeNumber.GetPrimesParallel(primeA, primeB));
        }
        private static void MeasureTime(Action ac)
        {
            Stopwatch sw = Stopwatch.StartNew();
            ac.Invoke();
            sw.Stop();
            Console.WriteLine("     Time = {0:F5} sec.", sw.ElapsedMilliseconds / 1000f);
        }
    }
}
