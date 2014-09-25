namespace _06.WordsCombination
{
    using System;
    using System.Collections.Generic;

   /// <summary>
   /// Write a program for generating and printing all subsets of k strings from given set of strings.
   /// Example: s = {test, rock, fun}, k=2
   /// (test rock),  (test fun),  (rock fun)
   /// </summary>
    class Program
    {
        private static List<string> list;
        private static string[] arr;
        static void Main(string[] args)
        {
            Console.Write("Enter number of k elements: ");
            int k = int.Parse(Console.ReadLine());

            Console.Write("Enter number n for the array size: ");
            int n = int.Parse(Console.ReadLine());

            list = new List<string>(k);

            for (int i = 0; i < k; i++)
            {
                Console.Write("Enter word or phrase: ");
                list.Add(Console.ReadLine());
            }

            arr = new string[n];
            Print(0, k, 1);
        }

        private static void Print(int index, int k, int nextCicle)
        {
            if (index == arr.Length)
            {
                
                Console.WriteLine(string.Join(" ", arr));
                return;
            }
            
            for (int i = nextCicle; i <= k; i++)
            {
                arr[index] = list[i - 1];
                Print(index + 1, k, i + 1);
            }
        }
    }
}
