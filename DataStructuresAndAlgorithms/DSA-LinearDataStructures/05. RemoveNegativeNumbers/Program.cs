namespace _05.RemoveNegativeNumbers
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Write a program that removes from given sequence all negative numbers.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter sequense of positive numbers (don't you dare to type negative numbers).");
            Console.WriteLine("Empty line for end");
            string stringNumber = Console.ReadLine();
            int number;
            bool isNumber = int.TryParse(stringNumber, out number);
            List<int> sequence = new List<int>();

            while (!string.IsNullOrEmpty(stringNumber))
            {
                if (isNumber && number >= 0)
                {
                    sequence.Add(number);
                }

                stringNumber = Console.ReadLine();
                isNumber = int.TryParse(stringNumber, out number);
            }

            Console.WriteLine(string.Join(", ", sequence));
        }
    }
}
