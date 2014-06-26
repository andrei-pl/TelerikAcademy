using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.FindMaxSum
{
    //Write a program that reads two integer numbers N and K and an array of N elements from the console. 
    //Find in the array those K elements that have maximal sum.

    class FindMaxSum
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write length of the array.");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter K:");
            int k = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("arr[" + i + "]");
                arr[i] = int.Parse(Console.ReadLine());
            }

            int maxSum = int.MinValue;
            for (int i = 1; i < Math.Pow(2, arr.Length) -1; i++)    //there are 2^numbers.length - 1 combinations
            {
                int sum = 0;
                int count = 0;
                for (int j = 0; j < arr.Length; j++)
                {
                    if (((i >> j) & 1) *arr[j] > 0)
                    {
                        sum += ((i >> j) & 1) * arr[j];
                        count++;
                    }
                    if (count == k && maxSum < sum)
                    {
                        maxSum = sum;
                    }
                }
            }
            Console.WriteLine("The maximal sum for K elements is: " + maxSum);
        }
    }
}
