using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17.SubsetSumKElements
{
    //* Write a program that reads three integer numbers N, K and S and an array of N elements from the console. 
    //Find in the array a subset of K elements that have sum S or indicate about its absence.

    class SubsetSumKElements
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write length of the array.");
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("arr[" + i + "]");
                arr[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter sum:");
            int sum = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of elements");      //This is a small difference between the two tasks (16 and 17)
            int k = int.Parse(Console.ReadLine());

            List<List<int>> newList = new List<List<int>>();

            for (int i = 1; i < Math.Pow(2, arr.Length) - 1; i++)    //there are 2^numbers.length - 1 combinations
            {
                List<int> subset = new List<int>();
                int tempSum = 0;
                int count = 0;                      //counter to check the length of created subset

                for (int j = 0; j < arr.Length; j++)
                {
                    if (((i >> j) & 1) * arr[j] > 0)
                    {
                        int subItem = ((i >> j) & 1) * arr[j];
                        tempSum += subItem;
                        subset.Add(subItem);
                        count++;
                    }
                }
                if (tempSum == sum && count == k)
                {
                    newList.Add(new List<int>(subset));
                }
            }
            if (newList.Capacity > 0)
            {
                Console.WriteLine("Yes");
                foreach (List<int> sub in newList)
                {
                    Console.WriteLine(string.Join(", ", sub));
                }
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
