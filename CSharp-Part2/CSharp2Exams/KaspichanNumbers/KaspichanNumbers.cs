using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspichanNumbers
{
    class KaspichanNumbers
    {
        static void Main(string[] args)
        {
            Dictionary<int , string> wordsText = new Dictionary<int, string>();
            for (int i = 0; i < 256; i++)
            {
                if (i >= 26)
                {
                    wordsText.Add(i, ((char)('a' + i / 26 - 1)).ToString() + ((char)('A' + i % 26)).ToString());
                }
                else
                {
                    wordsText.Add(i, ((char)('A' + i % 26)).ToString());
                }
            }

            ulong number = ulong.Parse(Console.ReadLine());
            int mod = 0;
            string newNumber = String.Empty;
            if (number == 0)
            {
                newNumber = "A";
            }
            while (number > 0)
            {
                mod = (int)(number % 256);
                number /= 256;
                newNumber = wordsText[mod] + newNumber;
            }
            Console.WriteLine(newNumber);

            //Convert from 256 to decimal
            //Dictionary<string, ulong> wordsText = new Dictionary<string, ulong>();
            //for (int i = 0; i < 256; i++)
            //{
            //    if (i >= 26)
            //    {
            //        wordsText.Add(((char)('a' + i / 26 - 1)).ToString() + ((char)('A' + i % 26)).ToString(), (ulong)i);
            //    }
            //    else
            //    {
            //        wordsText.Add(((char)('A' + i % 26)).ToString(), (ulong)i);
            //    }
            //}

            //string word = Console.ReadLine();
            //ulong num = 0;
            //int count = 0;
            //for (int i = word.Length - 1; i >= 0; i--)
            //{
            //    string number = word[i].ToString();

            //    if ((i - 1) >= 0 && word[i - 1] - 'a' >= 0)
            //    {
            //        number = word[i - 1] + number;
            //        i--;
            //    }
            //    num += wordsText[number] * ((ulong)Math.Pow(256, count));
            //    count++;
            //}
            //Console.WriteLine(num);
        }
    }
}
