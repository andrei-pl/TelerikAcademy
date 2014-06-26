using System;

namespace _04.HexadecimalToDecimal
{
    class HexadecimalToDecimal
    {
        //Write a program to convert hexadecimal numbers to their decimal representation.

        static int HexadecimalToDecimalRecursion(string num, int number = 0)
        {
            if (num == "")
            {
                return number;
            }
            if (num[0] >= 'A')
            {
                number += (num[0] - 'A' + 10) * (int)Math.Pow(16, num.Length - 1);
            }
            else
            {
                number += (num[0] - '0') * (int)Math.Pow(16, num.Length - 1);
            }
            return HexadecimalToDecimalRecursion(num.Remove(0, 1), number);
        }

        static void Main()
        {
            Console.WriteLine("Enter number:");
            string number = Console.ReadLine();
            Console.Write("The decimal number is ");
            Console.WriteLine(HexadecimalToDecimalRecursion(number));
        }
    }
}
