namespace _07.CountIntegersInArray
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Write a program that finds in given array of integers (all belonging to the range [0..1000]) how many times each of them occurs.
    ///Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
    ///2 -> 2 times
    ///3 -> 4 times
    ///4 -> 3 times
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter sequense of numbers.");
            Console.WriteLine("Empty line for end");
            string stringNumber = Console.ReadLine();
            int number;
            bool isNumber = int.TryParse(stringNumber, out number);
            List<int> sequence = new List<int>();
            IDictionary<int, int> dict = new SortedDictionary<int, int>();

            while (!string.IsNullOrEmpty(stringNumber))
            {
                if (isNumber)
                {
                    sequence.Add(number);
                    if (!dict.ContainsKey(number))
                    {
                        dict[number] = 0;
                    }
                    dict[number]++;
                }

                stringNumber = Console.ReadLine();
                isNumber = int.TryParse(stringNumber, out number);
            }

            foreach (var item in dict)
            {
                Console.WriteLine(item.Key + " -> " + item.Value + " times");
            }
        }
    }
}
