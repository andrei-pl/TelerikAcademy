namespace _08.MajorantOfArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// * The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times. Write a program to find the majorant of given array (if exists). 
    /// Example: {2, 2, 3, 3, 2, 3, 4, 3, 3} -> 3
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
            IDictionary<int, int> dict = new Dictionary<int, int>();

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

            var majorant = dict.OrderByDescending(x => x.Value).First();

            if (majorant.Value >= sequence.Count / 2 + 1)
            {
                Console.WriteLine(majorant.Key + " -> " + majorant.Value + " times");
            }
            else
            {
                Console.WriteLine("No majorant found");
            }
        }
    }
}
