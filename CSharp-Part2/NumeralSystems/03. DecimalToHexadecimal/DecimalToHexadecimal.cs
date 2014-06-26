using System;

namespace _03.DecimalToHexadecimal
{
    //Write a program to convert decimal numbers to their hexadecimal representation.

    class DecimalToHexadecimal
    {
        static string DecimalToHexadecimalRecursion(int num, string hex = "")
        {
            if (num == 0)
            {
                return hex;
            }
            if ((num & 15) > 9)
            {
                hex = (char)((num & 15) + 'A' - 10) + hex;
            }
            else
            {
                hex = (char)((num & 15) + '0') + hex;
            }
            return DecimalToHexadecimalRecursion(num >> 4, hex);
        }

        static void Main()
        {
            Console.WriteLine("Enter number:");
            int number = int.Parse(Console.ReadLine());
            Console.Write("In hexadecimal the number is ");
            Console.WriteLine(DecimalToHexadecimalRecursion(number));
        }
    }
}
