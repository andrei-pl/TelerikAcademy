using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.GreatestOfFive
{
    //Write a program that finds the greatest of given 5 variables.

    class GreatestOfFive
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 5 numbers:");
            Console.Write("1. ");
            double first = double.Parse(Console.ReadLine());
            Console.Write("2. ");
            double second = double.Parse(Console.ReadLine());
            Console.Write("3. ");
            double third = double.Parse(Console.ReadLine());
            Console.Write("4. ");
            double fourth = double.Parse(Console.ReadLine());
            Console.Write("5. ");
            double fifth = double.Parse(Console.ReadLine());

            double greatest = first;

            if (greatest < second)
            {
                greatest = second;
            }
            if (greatest < third)
            {
                greatest = third;
            }
            if (greatest < fourth)
            {
                greatest = fourth;
            }
            if (greatest < fifth)
            {
                greatest = fifth;
            }

            Console.WriteLine("The greatest number is: " + greatest);
        }
    }
}
