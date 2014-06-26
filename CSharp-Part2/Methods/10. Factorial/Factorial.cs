using System;
using System.Numerics;

namespace _10.Factorial
{
    //Write a program to calculate n! for each n in the range [1..100]. 
    //Hint: Implement first a method that multiplies a number represented as array of digits by given integer number. 

    class Factorial
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine(FactorialN(i));
            }
        }

        static BigInteger FactorialN(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            return n * FactorialN(n - 1);
        }
    }
}
