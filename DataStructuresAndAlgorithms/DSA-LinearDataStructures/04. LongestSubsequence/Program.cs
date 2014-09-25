namespace _04.LongestSubsequence
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Write a method that finds the longest subsequence of equal numbers in given List<int> and returns the result as new List<int>. 
    /// Write a program to test whether the method works correctly.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter sequense of numbers.");
            Console.WriteLine("Empty line for end");
            string stringNumber = Console.ReadLine();
            int number;
            int resultNumber = 0;
            int count = 0;
            int tempCounter = 0;
            bool isNumber = int.TryParse(stringNumber, out number);
            List<int> sequence = new List<int>();

            while (!string.IsNullOrEmpty(stringNumber))
            {
                if (isNumber)
                {
                    sequence.Add(number);
                }

                stringNumber = Console.ReadLine();
                isNumber = int.TryParse(stringNumber, out number);
            }

            if (sequence.Count != 0)
            {
                resultNumber = sequence[0];
                count = 1;
                tempCounter = 1;
            }

            for (int i = 1; i < sequence.Count; i++)
            {
                if (sequence[i] != sequence[i - 1])
                {
                    if (tempCounter > count)
                    {
                        count = tempCounter;
                        resultNumber = sequence[i - 1];
                    }
                    tempCounter = 0;
                }

                tempCounter++;
            }

            List<int> longestSequenceResult = new List<int>();
            for (int i = 0; i < count; i++)
            {
                longestSequenceResult.Add(resultNumber);
            }

            Console.WriteLine("The longest subsequence is: {0}", longestSequenceResult.Count != 0 ? string.Join(", ", longestSequenceResult) : "You don't type anything. What do you expected?");
        }
    }
}
