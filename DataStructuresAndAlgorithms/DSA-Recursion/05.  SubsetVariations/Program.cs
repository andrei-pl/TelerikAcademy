namespace _05.SubsetVariations
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Write a recursive program for generating and printing all ordered k-element subsets from n-element set (variations Vkn).
    /// Example: n=3, k=2, set = {hi, a, b} =>	(hi hi), (hi a), (hi b), (a hi), (a a), (a b), (b hi), (b a), (b b)
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
            Print(0, k, n);
        }

        private static void Print(int index, int k, int numberOfPhrases)
        {
            if (index == numberOfPhrases)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }
            
            for (int i = 1; i <= k; i++)
            {
                arr[index++] = list[i - 1];
                Print(index, k, numberOfPhrases);
                index--;
            }
        }
    }
}
