using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.SieveOfEratosthenes
{
    //Write a program that finds all prime numbers in the range [1...10 000 000]. Use the sieve of Eratosthenes algorithm (find it in Wikipedia).

    class SieveOfEratosthenes
    {
        static void Main(string[] args)
        {
            List<int> sieve = new List<int>();
            sieve.Add(1);
            sieve.Add(2);
            sieve.Add(3);
            sieve.Add(5);
            sieve.Add(7);

            for (int i = 8; i < 100; i++)
          //for (int i = 8; i < 10000000; i++)  //use on your responsibility ;)
            {
                if (i % 2 != 0 && i % 3 != 0 && i % 5 != 0 && i % 7 != 0)
                {
                    sieve.Add(i);
                }
            }
            Console.WriteLine(string.Join(", ", sieve));
        }
    }
}
