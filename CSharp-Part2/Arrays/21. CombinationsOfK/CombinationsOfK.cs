using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21.CombinationsOfK
{
    //Write a program that reads two numbers N and K and generates all the combinations of K distinct elements from the set [1..N]. 
    //Example:	N = 5, K = 2 -> {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}

    class CombinationsOfK
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] arrK = new int[k];

            CreateCombinations(arrK, 0, n, 1);
        }

        static void CreateCombinations(int[] arr, int k, int n, int start)
        {
            if (k == arr.Length)
            {
                Print(arr);
            }
            else
            {
                for (int i = start; i <= n; i++)
                {
                    arr[k] = i;
                    CreateCombinations(arr, k + 1, n, start + 1);
                }
            }
        }

        static void Print(int[] arr)
        {
            Console.WriteLine(string.Join(", ", arr));
        }
    }
}