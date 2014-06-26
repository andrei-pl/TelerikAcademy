using System;

namespace _05.HexadecimalToBinary
{
    class HexadecimalToBinary
    {
        //Write a program to convert hexadecimal numbers to binary numbers (directly).

        static int GetNumber(string s, int i)
        {
            if (s[i] >= 'A') return s[i] - 'A' + 10;
            else return s[i] - '0';
        }

        static string HexToBin(string num)
        {
            string binNumber = "";

            for (int i = num.Length - 1; i >= 0; i--)
                for (int j = 0, decNumber = GetNumber(num, i); j < 4; j++, decNumber = decNumber >> 1)
                    binNumber = (decNumber & 1) + binNumber;

            return binNumber;
        }

        static void Main()
        {
            Console.WriteLine("Enter hexadecimal number:");
            string number = Console.ReadLine();
            Console.Write("Binary representation is ");
            Console.WriteLine(HexToBin(number));
        }
    }
}
