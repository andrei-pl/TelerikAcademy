namespace _02._.ReverseNumbersInStack
{
    using System;
using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            ///Write a program that reads N integers from the console and reverses them using a stack. Use the Stack<int> class.
            Console.WriteLine("Enter sequense of numbers.");
            Console.WriteLine("Empty line for end");
            string stringNumber = Console.ReadLine();
            int number;
            bool isNumber = int.TryParse(stringNumber, out number);
            Stack<int> sequence = new Stack<int>();

            while (isNumber)
            {
                sequence.Push(number);

                stringNumber = Console.ReadLine();
                isNumber = int.TryParse(stringNumber, out number);
            }

            string reversedSequenceString  = String.Join(", ", sequence);

            Console.WriteLine("The reversed sequence is: {0}", reversedSequenceString);
        }
    }
}
