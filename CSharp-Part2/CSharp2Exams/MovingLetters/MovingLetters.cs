using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingLetters
{
    class MovingLetters
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            int max = 0;

            for (int i = 0; i < words.Length; i++)
            {
                if (max < words[i].Length)
                {
                    max = words[i].Length;
                }
            }

            StringBuilder text = new StringBuilder();

            for (int i = 0; i < max; i++)
            {
                for (int j = 0; j < words.Length; j++)
                {
                    int col = words[j].Length - 1 - i;
                    if (col >= 0)
                    {
                        text.Append(words[j][col]);
                    }
                }
            }

            StringBuilder newText = text;
            
            for (int i = 0; i < text.Length; i++)
            {
                int index = 0;
                if (newText[i] - 'A' < 26)
                {
                    index = (newText[i] - 'A' + 1 + i) % text.Length;
                }
                else
                {
                    index = (newText[i] - 'a' + 1 + i) % text.Length;
                }
                char letter = newText[i];
                newText.Remove(i, 1);
                newText.Insert(index, letter);
            }
            Console.WriteLine(newText);
        }
    }
}
