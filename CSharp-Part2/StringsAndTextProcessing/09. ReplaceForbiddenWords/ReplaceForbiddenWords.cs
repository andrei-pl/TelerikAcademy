﻿using System;
using System.Text.RegularExpressions;

namespace _09.ReplaceForbiddenWords
{
    //We are given a string containing a list of forbidden words and a text containing some of these words. 
    //Write a program that replaces the forbidden words with asterisks. Example:
    //Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.
		//Words: "PHP, CLR, Microsoft" The expected result:
    //********* announced its next generation *** compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in ***.


    class ReplaceForbiddenWords
    {
        static void Main(string[] args)
        {
            string text = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
            string words = "PHP, CLR, Microsoft";

            Console.WriteLine(Regex.Replace(text, words.Replace(", ", "|"), m => new string('*', m.Length)));
        }
    }
}
