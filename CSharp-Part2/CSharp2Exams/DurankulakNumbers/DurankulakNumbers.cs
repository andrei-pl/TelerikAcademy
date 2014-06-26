using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurankulakNumbers
{
    class DurankulakNumbers
    {
        static void Main(string[] args)
        {
            Dictionary<string, ulong> wordsText = new Dictionary<string, ulong>();
            for (int i = 0; i < 168; i++)
            {
                if (i >= 26)
                {
                    wordsText.Add(((char)('a' + i / 26 - 1)).ToString() + ((char)('A' + i % 26)).ToString(), (ulong)i);
                }
                else
                {
                    wordsText.Add(((char)('A' + i % 26)).ToString(), (ulong)i);
                }
            }

            string word = Console.ReadLine();
            ulong num = 0;
            int count = 0;
            for (int i = word.Length - 1; i >= 0; i--)
            {
                string number = word[i].ToString();

                if ((i - 1) >= 0 && word[i - 1] - 'a' >= 0)
                {
                    number = word[i - 1] + number;
                    i--;
                }
                num += wordsText[number] * ((ulong)Math.Pow(168, count));
                count++;
            }
            Console.WriteLine(num);
        }
    }
}
