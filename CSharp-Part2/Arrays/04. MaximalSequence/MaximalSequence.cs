using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.MaximalSequence
{
    //Write a program that finds the maximal sequence of equal elements in an array.
    //Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1} -> {2, 2, 2}.

    class MaximalSequence
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter array length: ");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            int count = 0;
            int value = 0;
            int maxCount = 0;
            int maxValue = 0;

            for (int i = 0; i < n; i++)
            {
                Console.Write((i + 1) + ". ");
                arr[i] = int.Parse(Console.ReadLine());

                if (value == arr[i])
                {
                    count++;
                }
                else
                {
                    if (count > maxCount)
                    {
                        maxCount = count;
                        maxValue = value;
                    }
                    count = 1;
                    value = arr[i];
                }
            }
            Console.Write(maxValue);
            for (int i = 0; i < maxCount - 1; i++)
            {
                Console.Write(", " + maxValue);
            }
            Console.WriteLine();
        }
    }
}
