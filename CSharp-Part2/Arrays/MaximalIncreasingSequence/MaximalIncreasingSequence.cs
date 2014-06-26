using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximalIncreasingSequence
{
    class MaximalIncreasingSequence
    {
        //Write a program that finds the maximal increasing sequence in an array. Example: {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.

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

                if (i > 0 && value + 1 == arr[i])
                {
                    count++;
                    value++;
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
            Console.Write(maxValue - maxCount + 1);
            for (int i = 1; i < maxCount; i++)
            {
                Console.Write(", " + (maxValue - maxCount + 1 + i));
            }
            Console.WriteLine();
        }
    }
}
