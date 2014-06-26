using System;
using System.Collections.Generic;
using System.Text;

namespace MultiverseCommunication
{
    class MultiverseCommunication
    {
        static ulong AnyToDecimalRecursion(string num, int pow, ulong number = 0)
        {
            if (num == "")
            {
                return number;
            }
            if (num[0] >= 'A')
            {
                number += (ulong)(num[0] - 'A' + 10) * (ulong)Math.Pow(pow, num.Length - 1);
            }
            else
            {
                number += (ulong)(num[0] - '0') * (ulong)Math.Pow(pow, num.Length - 1);
            }
            return AnyToDecimalRecursion(num.Remove(0, 1), pow, number);
        }

        static void Main(string[] args)
        {
            Dictionary<string, char> wordsText = new Dictionary<string, char>() { 
            { "CHU", '0' }, 
            { "TEL", '1' }, 
            { "OFT", '2' }, 
            { "IVA", '3' }, 
            { "EMY", '4' }, 
            { "VNB", '5' }, 
            { "POQ", '6' }, 
            { "ERI", '7' }, 
            { "CAD", '8' }, 
            { "K-A", '9' }, 
            { "IIA", 'A' }, 
            { "YLO", 'B' }, 
            { "PLA", 'C' } 
            };

            string word = Console.ReadLine();
            string number = String.Empty;

            for (int i = 0; i < word.Length; i += 3)
            {
                StringBuilder text = new StringBuilder();
                for (int j = i; j < i + 3; j++)
                {
                    text.Append(word[j]);
                }
                number += wordsText[text.ToString()];
            }
            ulong decimalNum = AnyToDecimalRecursion(number, 13);
            Console.WriteLine(decimalNum);
        }
    }
}
