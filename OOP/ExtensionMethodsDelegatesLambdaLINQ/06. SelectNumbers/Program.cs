using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.SelectNumbers
{
    class Program
    {
        //06. Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. 
        //Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.

        static void Main(string[] args)
        {
            int[] numbers = new int[100];
            for (int i = 0; i < 100; i++)
            {
                numbers[i] = i + 1;
            }

            var selectedNumbers = numbers.Where(x => x % 21 == 0);
            foreach (var item in selectedNumbers)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            selectedNumbers = from n in numbers
                              where n % 21 == 0
                              select n;

            foreach (var item in selectedNumbers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
