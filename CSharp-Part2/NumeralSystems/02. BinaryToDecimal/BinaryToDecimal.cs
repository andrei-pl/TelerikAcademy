using System;

namespace _02.BinaryToDecimal
{
    //Write a program to convert binary numbers to their decimal representation.

    class BinaryToDecimal
    {
        static int BinaryToDecimalRecursion(string num, int number = 0)
        {
            if (num == "")
            {
                return number;
            }
            if (num[0] == '0')
            {
                return BinaryToDecimalRecursion(num.Remove(0,1), number);
            }
            return BinaryToDecimalRecursion(num.Remove(0,1), number + (int)Math.Pow(2, num.Length - 1));
        }

        static void Main()
        {
            Console.WriteLine("Enter number:");
            string number = Console.ReadLine();
            Console.Write("The decimal number is ");
            Console.WriteLine(BinaryToDecimalRecursion(number));
        }
    }
}
