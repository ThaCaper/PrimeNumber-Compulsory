using System;
using System.Collections.Generic;
using System.Diagnostics;
using PrimeNumber_Compulsory;

namespace PrimeNumber_console
{
    class Program
    {
        private static PrimeGenerator primeNumber = new PrimeGenerator();   // Initialise our PrimeGenerator
        private static long a;  // Defines the start value
        private static long b;  // Defines the end value
        private static List<long> primes;   // Contains the a list with the result of prime numbers found.

        /// <summary>
        /// Main method here the magic happens. Contains a switch menu with options and own input field
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            // Should the programm continue after reaching the end 
            bool dontTerminate = true;

            // Aslong the user doesn't want the program terminated, we will repeat/restart from the beginning
            do
            {
                Console.WriteLine("Welcome to our 'Prime-Number in Range' Compulsory \n \n");
                Console.WriteLine("Please select option 1 - 4");
                Console.WriteLine("Option 1: 1 - 1.000.000");
                Console.WriteLine("Option 2: 1 - 10.000.000");
                Console.WriteLine("Option 3: 1.000.000 - 2.000.000");
                Console.WriteLine("Option 4: 10.000.000 - 20.000.000");
                Console.WriteLine("Option 5: Own Input");

                Console.Write("\n" + "Enter an option: ");

                int option = Int32.Parse(Console.ReadLine());

                // Menu
                switch (option)
                {
                    case 1:
                        Console.WriteLine("\n" + "Option 1 selected");
                        a = 1;
                        b = 1000000;
                        Console.WriteLine("Range: " + a + " - " + b);
                        break;
                    case 2:
                        Console.WriteLine("\n" + "Option 2 selected");
                        a = 1;
                        b = 10000000;
                        Console.WriteLine("Range: " + a + " - " + b);
                        break;
                    case 3:
                        Console.WriteLine("\n" + "Option 3 selected");
                        a = 1000000;
                        b = 2000000;
                        Console.WriteLine("Range: " + a + " - " + b);
                        break;
                    case 4:
                        Console.WriteLine("\n" + "Option 4 selected");
                        a = 10000000;
                        b = 20000000;
                        Console.WriteLine("Range: " + a + " - " + b);
                        break;
                    case 5:
                        Console.WriteLine("\n" + "Option 5 selected");
                        Console.Write("Enter start number: ");
                        a = Int32.Parse(Console.ReadLine());
                        Console.Write("Enter end number: ");
                        b = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Range: " + a + " - " + b);
                        break;
                }

                // spacer
                Console.WriteLine("\n \n");

                // Prints and measures time
                Console.WriteLine("GetPrimesSequential: (this may take a while...)");
                MeasureTime(() => GetPrimeNumbers(a, b));
                Console.WriteLine("GetPrimesParallel: (this may take a while...)");
                MeasureTime(() => GetPrimeNumberParallel(a, b));


                ////////////////////////////////////
                // Shall we print all primenumbers ?
                ////////////////////////////////////

                // Spacer
                Console.WriteLine("\n \n ");

                Console.Write("Print a list with all primes ? (Enter Y/N): ");
                string optionPrintPrimes = Console.ReadLine();

                if (optionPrintPrimes.ToLower().Equals("y"))
                {
                    primes.Sort();
                    foreach (var item in primes)
                    {
                        Console.Write(item + ", ");
                    }
                };


                ////////////////////////////////////
                // Shall the programm be terminated?
                ////////////////////////////////////

                // Spacer
                Console.WriteLine("\n");
                Console.Write("Back to menu or terminate program ? (Enter Y/N): ");
                string inputDontTerminate = Console.ReadLine();

                // terminate yes/no?
                if (inputDontTerminate.ToLower().Equals("y"))
                {
                    dontTerminate = true;
                }
                else if(inputDontTerminate.ToLower().Equals("n"))
                {
                    dontTerminate = false;
                }
                else
                {
                    dontTerminate = false;
                }


                ////////////////////////////////////
                // Shall we clear the console ?
                ////////////////////////////////////

                if(dontTerminate == true)
                {
                    // Spacer
                    Console.WriteLine("\n");
                    Console.Write("Clear the console ? (Enter Y/N): ");
                    string inputClearConsole = Console.ReadLine();

                    // terminate yes/no?
                    if (inputClearConsole.ToLower().Equals("y"))
                    {
                        Console.Clear();
                    }
                }


            } while (dontTerminate);

        }

        /// <summary>
        /// Gets primenumbers via sequential approach
        /// </summary>
        /// <param name="primeA"></param>
        /// <param name="primeB"></param>
        private static void GetPrimeNumbers(long primeA, long primeB)
        {
            primes = new List<long>(primeNumber.GetPrimesSequential(primeA, primeB));
        }

        /// <summary>
        /// Gets primenumbers via using the parallel approach
        /// </summary>
        /// <param name="primeA"></param>
        /// <param name="primeB"></param>
        private static void GetPrimeNumberParallel(long primeA, long primeB)
        {
            primes = new List<long>(primeNumber.GetPrimesParallel(primeA, primeB));
        }


        /// <summary>
        /// Measures the time
        /// </summary>
        /// <param name="ac"></param>
        private static void MeasureTime(Action ac)
        {
            Stopwatch sw = Stopwatch.StartNew();
            ac.Invoke();
            sw.Stop();
            Console.WriteLine("     Time = {0:F5} sec.", sw.ElapsedMilliseconds / 1000f);
        }
    }
}
