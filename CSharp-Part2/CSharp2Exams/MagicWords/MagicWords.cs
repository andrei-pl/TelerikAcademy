using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicWords
{
    class MagicWords
    {
        static List<string> reorder(List<string> words)
        {
            List<string> newList = new List<string>(words);

            for (int pos = 0; pos < words.Count; pos++)
			{
                string word = newList[pos];
                int newPos = newList[pos].Length % (words.Count + 1);
                newList[pos] = null; // Mark the word for deleting
                newList.Insert(newPos, word);
                newList.Remove(null);
            }
            return newList;
        }

        static void Main(string[] args)
        {
            List<string> words = new List<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                words.Add(Console.ReadLine());
            }

            words = reorder(words);
            int maxIndex = 0;

            foreach (var item in words)
            {
                if (item.Length > maxIndex)
                {
                    maxIndex = item.Length;
                }
            }

            StringBuilder text = new StringBuilder();
            for (int i = 0; i < maxIndex; i++)
            {
                for (int j = 0; j < words.Count; j++)
                {
                    if (words[j].Length > i)
                    {
                        text.Append(words[j][i]);
                    }
                }
            }
            Console.WriteLine(text);
        }
    }
}
