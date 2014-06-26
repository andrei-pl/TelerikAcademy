using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _23.ReplaceConsecutiveLetters
{
    //Write a program that reads a string from the console and replaces all series of consecutive identical letters with a single one. 
    //Example: "aaaaabbbbbcdddeeeedssaa" -> "abcdedsa".

    class ReplaceConsecutiveLetters
    {
        static void Main(string[] args)
        {
            string text = "aaaaabbbbbcdddeeeedssaa";
            StringBuilder newText = new StringBuilder();
            newText.Append(text[0].ToString());

            for (int i = 0; i < text.Length; i++)
            {
                if (newText[newText.Length - 1] != text[i])
                {
                    newText.Append(text[i].ToString());
                }
            }
            Console.WriteLine(newText.ToString());

            //Console.WriteLine(Regex.Replace(text, @"(\w)\1+", "$1"));  //short variant
        }
    }
}
