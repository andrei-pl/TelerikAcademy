using System;
using System.Numerics;

namespace _07.FibonacciSum
{
    class FibonacciSum
    {
        //Write a program that reads a number N and calculates the sum of the first N members of 
        //the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
        //Each member of the Fibonacci sequence (except the first two) is a sum of the previous two members.

        static void Main(string[] args)
        {
            Console.WriteLine("Enter to which number of the sequence of Fibonacci you want to see the sum: ");
            int n = int.Parse(Console.ReadLine());

            BigInteger prev = 0L;
            BigInteger curr = 1L;
            BigInteger next = prev + curr;

            if (n > 0)
            {
                Console.WriteLine("1. " + prev);
                Console.WriteLine("2. " + curr);
                for (int i = 3; i <= n; i++)
                {
                    next = prev + curr;
                    prev = curr;
                    curr = next;
                    Console.WriteLine(i + ". " + next);
                }
            }
            else
            {
                Console.WriteLine("Invalid number!");
            }
        }
    }
}
