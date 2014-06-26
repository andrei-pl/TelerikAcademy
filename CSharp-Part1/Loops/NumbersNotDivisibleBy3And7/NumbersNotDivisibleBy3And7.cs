using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersNotDivisibleBy3And7
{
    //Write a program that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time.

    class NumbersNotDivisibleBy3And7
    {
        static void Main(string[] args)
        {
            Console.Write("Enter to which number to print: ");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine("The numbers which are not divisible to 3 and 7 are:");

            for (int i = 1; i <= number; i++)
            {
                if ((i % 21) > 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
