using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.SubsetWithSumS
{
    //* We are given an array of integers and a number S. Write a program to find if there exists a subset of the elements of the array that has a sum S. 
    //Example: arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14 -> yes (1+2+5+6)

    class SubsetWithSumS
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

            List<List<int>> newList = new List<List<int>>();

            for (int i = 1; i < Math.Pow(2, arr.Length) - 1; i++)    //there are 2^numbers.length - 1 combinations
            {
                List<int> subset = new List<int>();
                int tempSum = 0;
                for (int j = 0; j < arr.Length; j++)
                {
                    if (((i >> j) & 1) * arr[j] > 0)
                    {
                        int subItem = ((i >> j) & 1) * arr[j];
                        tempSum += subItem;
                        subset.Add(subItem);
                    }
                }
                if (tempSum == sum)
                {
                    newList.Add(new List<int>(subset));
                }
            }
            if (newList.Capacity > 0)
            {
                Console.WriteLine("Yes");
                foreach (List<int> sub in newList)
                {
                    Console.WriteLine(string.Join(" + ", sub));
                }
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
