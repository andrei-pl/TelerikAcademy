using System;
using System.Text.RegularExpressions;

namespace _18.ExtractEmails
{
    //Write a program for extracting all email addresses from given text. 
    //All substrings that match the format <identifier>@<host>…<domain> should be recognized as emails.

    class ExtractEmails
    {
        static void Main(string[] args)
        {
            string str = "Contact Telerik at,telerik@telerik.com or nakov@gmail.com";

            foreach (var item in Regex.Matches(str, @"\w+@\w+\.\w+"))
            {
                Console.WriteLine(item);
            }
        }
    }
}
