using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18.RemoveMinElements
{
    // Write a program that reads an array of integers and removes from it a minimal
    // number of elements in such way that the remaining array is sorted in increasing
    // order. Print the remaining sorted array.
    // Example: {6, 1, 4, 3, 0, 3, 6, 4, 5} -> {1, 3, 3, 4, 5}

    class RemoveMinElements
    {
        static void Main()
        {
            Console.WriteLine("Write length of the array.");
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("arr[" + i + "]");
                arr[i] = int.Parse(Console.ReadLine());
            }

            List<int> list = new List<int>();

            for (int i = 1; i < Math.Pow(2, arr.Length) - 1; i++)    //there are 2^numbers.length - 1 combinations
            {
                List<int> subset = new List<int>();
                for (int j = 0; j < arr.Length; j++)
                {
                    if (((i >> j) & 1) * arr[j] > 0)
                    {
                        int subItem = ((i >> j) & 1) * arr[j];
                        if (subset.Count == 0)
                        {
                            subset.Add(subItem);
                        }
                        else
                        {
                            if (subset[subset.Count - 1] <= subItem)
                            {
                                subset.Add(subItem);
                            }
                        }
                    }
                }
                if (subset.Count > list.Count)
                {
                    list = new List<int>(subset);
                }
            }
            
            Console.WriteLine(string.Join(", ", list));
        }
    }
}