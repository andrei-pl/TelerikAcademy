using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.SubsetSumnEqualToZero
{
    class SubsetSumnEqualToZero
    {
        //We are given 5 integer numbers. Write a program that checks if the sum of some subset of them is 0. Example: 3, -2, 1, 1, 8  1+1-2=0.

        static void Main(string[] args)
        {
            int[] numbers = new int[5];
            int counter = 0;
            for (int i = 0; i < 5; i++)
            {
                numbers[i] = Int32.Parse(Console.ReadLine());
            }
            for (int i = 1; i < 32; i++)    //there is 31 combinations (2^numbers.length - 1)
            {
                int sum = 0;
                for (int j = 0; j < 5; j++)
                {
                    sum += ((i >> j) & 1) * numbers[j];
                }
                if (sum == 0)
                {
                    counter++;
                }
            }
            Console.WriteLine("There are " + counter + " subset sums = 0");
        }
    }
}