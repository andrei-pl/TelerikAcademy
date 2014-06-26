using System;
using System.Collections.Generic;

namespace _20.VariationsOfK
{
    //Write a program that reads two numbers N and K and generates all the variations of K elements from the set [1..N]. 
    //Example: N = 3, K = 2  {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}

    class VariationsOfK
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] arrK = new int[k];

            CreateVariations(arrK, 0, n);
        }

        static void CreateVariations(int[] arr, int index, int n)
        {
            if (index >= arr.Length)
            {
                Print(arr);
            }
            else
            {
                for (int i = 1; i <= n; i++)
                {
                    arr[index] = i;
                    CreateVariations(arr, index + 1, n);
                }
            }
        }

        static void Print(int[] arr)
        {
            Console.WriteLine(string.Join(", ", arr));
        }
    }
}
