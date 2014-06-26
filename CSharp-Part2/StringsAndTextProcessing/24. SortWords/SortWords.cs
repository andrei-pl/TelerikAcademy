using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _24.SortWords
{
    //Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.

    class SortWords
    {
        static void Main(string[] args)
        {
            string text = "Write a program that Program reads a list of words, separated by spaces and prints the list in an alphabetical order.";
            List<string> list = new List<string>(text.Trim().Split(new string[] { " ", ",", ".", "!" }, StringSplitOptions.RemoveEmptyEntries));
            list.Sort();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            //Variant 2
            //var words = new List<string>();

            //foreach (Match word in Regex.Matches(text, @"\w+"))
            //    words.Add(word.Value);

            //words.Sort();

            //foreach (string word in words)
            //    Console.WriteLine(word);
        }
    }
}
