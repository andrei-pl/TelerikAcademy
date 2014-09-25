namespace _06.RemoveNumbers
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Write a program that removes from given sequence all numbers that occur odd number of times. 
    /// Example: {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2} -> {5, 3, 3, 5}
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
            Dictionary<int, int> dict = new Dictionary<int, int>();

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
                if (item.Value % 2 != 0)
                {
                    while (sequence.IndexOf(item.Key) != -1)
                    {
                        sequence.Remove(item.Key);
                    }
                }
            }
            Console.WriteLine(string.Join(", ", sequence));
        }
    }
}
