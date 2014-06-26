using System;
using System.Text.RegularExpressions;

namespace _04.CountSubstring
{
    //Write a program that finds how many times a substring is contained in a given text (perform case insensitive search).
	//Example: The target substring is "in". The text is as follows:
    //We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. 
    //So we are drinking all the day. We will move out of it in 5 days.
    //The result is: 9.

    class CountSubstring
    {
        static void Main(string[] args)
        {
            string text = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
            int count = 0;
            int index = -1;
            while ((index = text.IndexOf("in", index + 1, StringComparison.CurrentCultureIgnoreCase)) != -1)
            {
                count++;
            }
            Console.WriteLine("The result is: " + count);

            //Variant 2
            //string subStr = "in";
            //Console.WriteLine("The result is: " + Regex.Matches(text, subStr, RegexOptions.IgnoreCase).Count);  
        }
    }
}
