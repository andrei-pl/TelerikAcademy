using System;

namespace _06.SumFromString
{
    //You are given a sequence of positive integer values written into a string, separated by spaces. 
    //Write a function that reads these values from given string and calculates their sum. Example:	string = "43 68 9 23 318" -> result = 461

    class SumFromString
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter numbers separated by spaces between them");
            string[] numString = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            int sum = SumNumbers(numString);
            Console.WriteLine("The sum is: " + sum);
        }

        private static int SumNumbers(string[] numString)
        {
            int[] numbers = new int[numString.Length];
            int sum = 0;
            for (int i = 0; i < numString.Length; i++)
            {
                numbers[i] = int.Parse(numString[i]);
                sum += numbers[i];
            }
            return sum;
        }
    }
}
