using System;

namespace _06.BinaryToHexadecimal
{
    //Write a program to convert binary numbers to hexadecimal numbers (directly).

    class BinaryToHexadecimal
    {
        static char GetChar(int i)
        {
            if (i >= 10) return (char)('A' + i - 10);
            else return (char)('0' + i);
        }

        static int GetNumber(string s, int i)
        {
            return s[i] - '0';
        }

        static string BinToHex(string num)
        {
            if (num.Length % 4 != 0) return BinToHex(new String('0', 4 - num.Length % 4) + num); // Padleft

            string hexNumber = "";

            for (int i = num.Length - 1; i >= 0; i -= 4)
            {
                int nibble = 0;

                for (int j = 0, power = 1; j < 4; j++, power *= 2)
                    nibble += GetNumber(num, i - j) * power;

                hexNumber = GetChar(nibble) + hexNumber;
            }

            return hexNumber;
        }

        static void Main()
        {
            Console.WriteLine("Enter binary number:");
            string number = Console.ReadLine();
            Console.Write("Hexadecimal representation is ");
            Console.WriteLine(BinToHex(number));
        }
    }
}
