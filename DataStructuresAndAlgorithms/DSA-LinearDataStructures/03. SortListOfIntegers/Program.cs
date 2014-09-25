namespace _03.SortListOfIntegers
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Write a program that reads a sequence of integers (List<int>) ending with an empty line and sorts them in an increasing order.
    /// </summary>

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter sequense of numbers.");
            Console.WriteLine("Empty line for end");
            string stringNumber = Console.ReadLine();
            int number;
            bool isNumber = int.TryParse(stringNumber, out number);
            List<int> sequence = new List<int>();

            while (isNumber)
            {
                sequence.Add(number);

                stringNumber = Console.ReadLine();
                isNumber = int.TryParse(stringNumber, out number);
            }

            sequence.Sort();
            Console.WriteLine("The sorted sequence is: {0}", string.Join(", ", sequence));
        }
    }
}
