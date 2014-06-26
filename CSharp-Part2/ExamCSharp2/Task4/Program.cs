using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string[], int> dict = new Dictionary<string[], int>();
            string word = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            string[][] paragraph = new string[n][];

            for (int i = 0; i < n; i++)
			{
                int counter = 0;
                paragraph[i] = Console.ReadLine().Split(new string[] { ",", ".", "(", ")", ";", "-", "!", "?", " " }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < paragraph[i].Length; j++ )
                {
                    if (word.ToLower() == paragraph[i][j].ToLower())
                    {
                        paragraph[i][j] = paragraph[i][j].ToUpper();
                        counter++;
                    }
                }
                dict[paragraph[i]] = counter;
			}

            foreach (var item in dict.OrderByDescending(x => x.Value))
            {
                string[] text = item.Key;
                foreach (var result in text)
                {
                    Console.Write(result + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
