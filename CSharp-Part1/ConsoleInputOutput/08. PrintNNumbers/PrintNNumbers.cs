using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.PrintNNumbers
{
    class PrintNNumbers
    {
        //Write a program that reads an integer number n from the console and prints all the numbers in the interval [1..n], each on a single line

        static void Main(string[] args)
        {
            Console.Write("Enter to which number to print numbers: ");
            int n = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(i + 1);
            }
        }
    }
}
