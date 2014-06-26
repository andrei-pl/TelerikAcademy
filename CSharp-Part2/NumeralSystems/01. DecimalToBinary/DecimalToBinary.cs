using System;

namespace _01.DecimalToBinary
{
    //Write a program to convert decimal numbers to their binary representation.

    class DecimalToBinary
    {
        static string DecimalToBinaryRecursion(int num, string binary = "")
        {
            return num == 0 ? binary : DecimalToBinaryRecursion(num >> 1, (num & 1) + binary);
        }

        static void Main()
        {
            Console.WriteLine("Enter number:");
            int number = int.Parse(Console.ReadLine());
            Console.Write("In binary the number is ");
            Console.WriteLine(DecimalToBinaryRecursion(number));
        }
    }
}
