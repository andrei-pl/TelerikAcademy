using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostFrequentNumber
{
    //Write a program that finds the most frequent number in an array. Example:
	//{4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} -> 4 (5 times)

    class MostFrequentNumber
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write array length");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
           
            for (int i = 0; i < n; i++)
            {
                Console.Write((i + 1) + ". ");
                arr[i]  = int.Parse(Console.ReadLine());
            }

            int frequentNumber = 0;
            int count = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int tempNumber = arr[i];
                int tempCount = 0;
                for (int j = i; j < arr.Length; j++)
                {
                    if(arr[i] == arr[j])
                    {
                        tempCount++;
                    }
                }
                if (count < tempCount)
                {
                    count = tempCount;
                    frequentNumber = arr[i];
                }
            }
            Console.WriteLine(frequentNumber + " (" + count + " times)");
        }
    }
}
