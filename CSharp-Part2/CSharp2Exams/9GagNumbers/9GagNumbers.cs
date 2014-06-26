using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9GagNumbers
{
    class Program
    {
        static ulong AnyToDecimalRecursion(string num)
        {
            ulong result = 0;
            for (int i = 0; i < num.Length; i++)
            {
                ulong number = 1;
                ulong value = ulong.Parse(num[i].ToString());
                for (int j = num.Length - i - 2; j >= 0; j--)
                {
                    number *= 9;
                }
                value *= number;
                result += value;
            }
            return result;
        }

        static void Main(string[] args)
        {
            Dictionary<string, char> wordsText = new Dictionary<string, char>() { 
            { "-!", '0' }, 
            { "**", '1' }, 
            { "!!!", '2' }, 
            { "&&", '3' }, 
            { "&-",'4' }, 
            { "!-", '5' }, 
            { "*!!!",'6' }, 
            { "&*!", '7' }, 
            { "!!**!-", '8' } 
            };

            string word = Console.ReadLine();
            string number = String.Empty;
            StringBuilder text = new StringBuilder();

            for (int i = 0; i < word.Length; i++)
            {
                text.Append(word[i]);
                if (wordsText.ContainsKey(text.ToString()))
                {
                    number += wordsText[text.ToString()];
                    text.Clear();
                }
            }
            ulong decimalNum = AnyToDecimalRecursion(number);
            Console.WriteLine(decimalNum);
        }}
}
