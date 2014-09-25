namespace NumberOfOccurencies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Globalization;
    using System.Threading;

    /// <summary>
    /// Write a program that counts in a given array of double values the number of occurrences of each value. Use Dictionary<TKey,TValue>.
    /// Example: array = {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5}
    /// -2.5 -> 2 times
    /// 3 -> 4 times
    /// 4 -> 3 times
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Console.WriteLine("Enter sequense of numbers (double or integer, separated by \",\").");
            string[] numberStr = Console.ReadLine().Split(',');     //double[] number = Console.Readline().Split(',').Select(h => double.Parse(h)).ToArray();
            double[] number = Array.ConvertAll<string, double>(numberStr, double.Parse);

            IDictionary<double, int> dict = new SortedDictionary<double, int>();

            foreach (var item in number)
            {
                if (!dict.ContainsKey(item))
                    {
                        dict[item] = 0;
                    }
                    dict[item]++;
            }

            foreach (var item in dict)
            {
                Console.WriteLine(item.Key + " -> " + item.Value + " times");
            }
        }
    }
}
