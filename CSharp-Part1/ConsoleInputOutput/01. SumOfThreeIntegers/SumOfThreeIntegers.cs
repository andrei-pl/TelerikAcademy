using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SumOfThreeIntegers
{
    //Write a program that reads 3 integer numbers from the console and prints their sum.

    class SumOfThreeIntegers
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first integer \"a\": ");
            int a = Int32.Parse(Console.ReadLine());
            Console.Write("Enter second integer \"b\": ");
            int b = Int32.Parse(Console.ReadLine());
            Console.Write("Enter third integer \"c\": ");
            int c = Int32.Parse(Console.ReadLine());

            Console.WriteLine("a + b + c = " + (a + b + c));
        }
    }
}
