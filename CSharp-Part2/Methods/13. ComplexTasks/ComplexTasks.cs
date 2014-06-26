using System;

namespace _13.ComplexTasks
{
    /* Write a program that can solve these tasks:
Reverses the digits of a number
Calculates the average of a sequence of integers
Solves a linear equation a * x + b = 0
		Create appropriate methods.
		Provide a simple text-based menu for the user to choose which task to solve.
		Validate the input data:
The decimal number should be non-negative
The sequence should not be empty
a should not be equal to 0
    */
    class ComplexTasks
    {
        static void Main(string[] args)
        {
            int choise;
            do
            {
                GivingValue(@"Choose what you want to do (1 - 3):

0. Exit
1. Reverses the digits of a number
2. Calculates the average of a sequence of integers
3. Solves a linear equation a * x + b = 0
", out choise);

                int arrayLength = 0;
                decimal number1;
                decimal number2;
                decimal[] sequence = new decimal[arrayLength];
                switch (choise)
                {
                    case 0:
                        Console.WriteLine("Bye");
                        break;
                    case 1:
                        do
                        {
                            GivingValue("Enter positive number: ", out number1);
                        } while (number1 <= 0);
                        Console.WriteLine("The inverted number is: " + ReverseNumber(number1));
                        break;
                    case 2:
                        do
                        {
                            GivingValue("Enter length for the sequence: ", out arrayLength);
                        } while (arrayLength <= 0);

                        sequence = new decimal[arrayLength];
                        for (int i = 0; i < sequence.Length; i++)
                        {
                            GivingValue((i + 1) + ". ", out sequence[i]);
                        }

                        Console.WriteLine("The average sum of this sequence is: " + AverageOfSequence(sequence));
                        break;
                    case 3:
                        do
                        {
                            GivingValue("Enter number for \"a\": ", out number1);
                        } while (number1 == 0);
                        GivingValue("Enter number for \"b\": ", out number2);

                        Console.WriteLine("Solution of the linear equation is: " + LinearEquation(number1, number2));
                        break;
                    default: Console.WriteLine("Invalid choise"); break;
                }
                Console.WriteLine();
            } while (choise != 0);
        }

        static void GivingValue(string text, out decimal number)
        {
            do
            {
                Console.Write(text);
            } while (!decimal.TryParse(Console.ReadLine(), out number));
        }

        static void GivingValue(string text, out int number)
        {
            do
            {
                Console.Write(text);
            } while (!int.TryParse(Console.ReadLine(), out number));
        }

        static decimal ReverseNumber(decimal number)
        {
            string strNumber = number.ToString();
            string newNumber = "";

            for (int i = strNumber.Length - 1; i >= 0; i--)
            {
                newNumber += strNumber[i].ToString();
            }
            return decimal.Parse(newNumber);
        }

        static decimal AverageOfSequence(decimal[] sequence)
        {
            decimal sum = 0;
            for (int i = 0; i < sequence.Length; i++)
            {
                sum += sequence[i];
            }
            return sum /= sequence.Length;
        }

        static decimal LinearEquation (decimal a, decimal b)
        {
            return (-b) / a;
        }
    }
}
