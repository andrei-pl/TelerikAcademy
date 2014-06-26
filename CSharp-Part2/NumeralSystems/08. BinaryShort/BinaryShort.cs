using System;

namespace _08.BinaryShort
{
    //Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short).

    class BinaryShort
    {
        static string GetBinary(short num)
        {
            string binaryNum = "";

            for (int i = 0; i < 16; i++) binaryNum = ((num >> i) & 1) + binaryNum;

            return binaryNum;
        }

        static void Main()
        {
            Console.WriteLine("Enter short number:");
            short number = short.Parse(Console.ReadLine());
            Console.Write("Binary representation is ");
            Console.WriteLine(GetBinary(number));
        }
    }
}
