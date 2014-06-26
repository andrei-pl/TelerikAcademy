using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.MinAndMaxOfNNumbers
{
    class MinAndMaxOfNNumbers
    {
        //Write a program that reads from the console a sequence of N integer numbers and returns the minimal and maximal of them.

        static void Main(string[] args)
        {
            Console.Write("How many integer numbers you want to compare: ");
            int numbers = int.Parse(Console.ReadLine());

            int min = int.MaxValue;
            int max = int.MinValue;

            for (int i = 0; i < numbers; i++)
            {
                int intNumber;
                Console.Write((i + 1) + ". ");
                intNumber = int.Parse(Console.ReadLine());

                if (min > intNumber)
                {
                    min = intNumber;
                }
                if (intNumber > max)
                {
                    max = intNumber;
                }
            }
            Console.WriteLine("Min = " + min);
            Console.WriteLine("Max = " + max);
        }
    }
}
