using System;

namespace _11.PrintNumber
{
    //Write a program that reads a number and prints it as a decimal number, hexadecimal number, percentage and in scientific notation. 
    //Format the output aligned right in 15 symbols.

    class PrintNumber
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number");
            double number = double.Parse(Console.ReadLine());

            Console.WriteLine("{0,15}, {1,15:X}, {0,15:P}, {0,15:E}", number, (int)number);
        }
    }
}
