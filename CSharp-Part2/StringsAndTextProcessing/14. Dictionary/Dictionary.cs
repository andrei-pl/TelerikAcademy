using System;
using System.Collections.Generic;

namespace _14.Dictionary
{
    //A dictionary is stored as a sequence of text lines containing words and their explanations. 
    //Write a program that enters a word and translates it by using the dictionary. Sample dictionary:
    //.NET – platform for applications from Microsoft
    //CLR – managed execution environment for .NET
    //namespace – hierarchical organization of classes

    class Dictionary
    {
        static void Main(string[] args)
        {
            IDictionary<string, string> translateWords = new Dictionary<string, string>();
            translateWords[".NET"] = "platform for applications from Microsoft";
            translateWords["CLR"] = "managed execution environment for .NET";
            translateWords["namespace"] = "hierarchical organization of classes";

            Console.WriteLine(@"Enter "".NET"", ""CLR"" or ""namespace"" to explain");
            string name = Console.ReadLine(); ;

            TranslateWord(name, translateWords);
        }
        static void TranslateWord(string name, IDictionary<string, string> word)
        {
            if (word.ContainsKey(name))
            {
                string value = word[name];
                Console.WriteLine("{0}", value);
            }
            return;
        }
    }
}
