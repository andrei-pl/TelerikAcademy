namespace _1.SumAndAverageOfSequence
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        /// <summary>
        ///  Write a program that reads from the console a sequence of positive integer numbers. 
        ///  The sequence ends when empty line is entered. Calculate and print the sum and average of the elements of the sequence. </summary>
        ///  Keep the sequence in List<int>.
        ///  <param name="args"></param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter sequense of positive numbers.");
            Console.WriteLine("Empty line for end");
            string stringNumber = Console.ReadLine();
            int number;
            bool isNumber = int.TryParse(stringNumber, out number);
            List<int> sequence = new List<int>();
            int sumNumbers = 0;
            int currentNumber = Math.Abs(number);

            while (isNumber)
            {
                sequence.Add(currentNumber);

                sumNumbers += currentNumber;

                stringNumber = Console.ReadLine();
                isNumber = int.TryParse(stringNumber, out number);
                currentNumber = Math.Abs(number);
            }

            Console.WriteLine("Sum of the sequence is: {0}", sumNumbers);
            Console.WriteLine("Average of the sequence is: {0}", sumNumbers / sequence.Count);
        }
    }
}
