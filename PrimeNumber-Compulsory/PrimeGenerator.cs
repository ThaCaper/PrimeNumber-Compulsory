using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeNumber_Compulsory
{
    public class PrimeGenerator
    {
        private object locker = new object();
        public PrimeGenerator()
        {

        }

        public List<long> GetPrimesSequential(long first, long last)
        {
            var primeNumbers = new List<long>();
            for (long i = first; i <= last; i++)
            {
                //Assume each number is a prime number
                bool isPrime = true;

                //For loops with the power of math to ascertain the actuality of prime status
                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    //Wasn't actually a prime number.
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                //Adds the prime number to the list.
                if (isPrime && i!=0 && i!= 1)
                {
                    primeNumbers.Add(i);
                }
            }
            return primeNumbers;
        }

        public List<long> GetPrimesParallel(long first, long last)
        {
            var primeNumbers = new List<long>();
            Parallel.ForEach(Partitioner.Create(first, last), (range =>
            {
                for (long i = range.Item1; i <= range.Item2; i++)
                {
                    //Assume each number is a prime number
                    bool isPrime = true;

                    //For loops with the power of math to ascertain the actuality of prime status
                    for (int j = 2; j <= Math.Sqrt(i); j++)
                    {
                        //Wasn't actually a prime number.
                        if (i % j == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }

                    //Adds the prime number to the list.
                    if (isPrime && i != 0 && i != 1)
                    {
                        lock (locker)
                        {
                            primeNumbers.Add(i);
                        }
                    }
                }
            }));
            return primeNumbers;
        }
    }
}