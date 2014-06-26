using System;
using System.Text.RegularExpressions;

namespace _08.ContainWord
{
    //Write a program that extracts from a given text all sentences containing given word.
		//Example: The word is "in". The text is:
    //We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. 
    //So we are drinking all the day. We will move out of it in 5 days.
    	//The expected result is:
    //We are living in a yellow submarine.
    //We will move out of it in 5 days.
	//Consider that the sentences are separated by "." and the words – by non-letter symbols.

    class ContainWprd
    {
        static void Main(string[] args)
        {
            string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
            string[] sentences = text.Split('.');
            string word = "in";

            for (int i = 0; i < sentences.Length; i++)
            {
                if(Regex.IsMatch(sentences[i], @"\b" + word + @"\b"))
                    Console.WriteLine(sentences[i].Trim() + ".");
            }
            //Variant 2
            //foreach (Match sentence in Regex.Matches(text, @"\s*([^\.]*\b" + word + @"\b.*?\.)"))
            //    Console.WriteLine(sentence.Groups[1]);
        }
    }
}
