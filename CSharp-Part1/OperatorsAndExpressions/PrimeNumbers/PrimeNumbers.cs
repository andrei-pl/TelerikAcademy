using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumbers
{
    class PrimeNumbers
    {
        //Write an expression that checks if given positive integer number n (n ≤ 100) is prime. E.g. 37 is prime.

        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int number = Int32.Parse(Console.ReadLine());

            bool isPrime = true;

            if (number > 0 && number <= 100)
            {
                for (int i = 2; i <= number / 2; i++)
                {
                    if (number % i == 0)
                    {
                        isPrime = false;
                    }
                }
                if (isPrime)
                {
                    Console.WriteLine("The number is prime.");
                }
                else
                {
                    Console.WriteLine("The number is not prime.");
                }
            }
            else
            {
                Console.WriteLine("The number is out of range.");
            }
        }
    }
}
