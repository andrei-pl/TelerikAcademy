namespace _3.CountWordsFromFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Write a program that counts how many times each word from given text file words.txt appears in it. 
    /// The character casing differences should be ignored. The result words should be ordered by their number of occurrences in the text. 
    /// Example:
    /// This is the TEXT. Text, text, text – THIS TEXT! Is this the text?
    /// is  2
    /// the  2
    /// this  3
    /// text  6
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StreamReader reader = new StreamReader(@"../../text.txt");

                using (reader)
                {
                    string text = reader.ReadToEnd();
                    char[] separators = { ' ', '.', ',', '!', '–', '?', '-' };
                    string[] values = text.ToLower().Split(separators, StringSplitOptions.RemoveEmptyEntries);

                    Dictionary<string, int> dictionary = new Dictionary<string, int>();

                    foreach (var value in values)
                    {
                        if (!dictionary.ContainsKey(value))
                        {
                            dictionary[value] = 0;
                        }
                        dictionary[value]++;
                    }

                    foreach (var item in dictionary.OrderBy(x => x.Value).ThenBy(x => x.Key))
                    {
                        Console.WriteLine("{0} -> {1} times", item.Key, item.Value);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Missing File");
            }
        }
    }
}
