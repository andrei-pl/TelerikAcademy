using System;
using System.Text.RegularExpressions;

namespace _05.UpperCaseTags
{
    class UpperCaseTags
    {
        //You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase> and </upcase> to uppercase. 
        //The tags cannot be nested. Example:
        //We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.
        //The expected result: We are living in a YELLOW SUBMARINE. We don't have ANYTHING else.

        static void Main(string[] args)
        {
            string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";

            string openTag = "<upcase>";
            string closedTag = "</upcase>";

            while (text.IndexOf(openTag) != -1)
            {
                int startIndex = text.IndexOf(openTag);
                int lastIndex = text.IndexOf(closedTag);
                string upperText = text.Substring(startIndex + openTag.Length, lastIndex - startIndex - openTag.Length);
                text = text.Replace(openTag + upperText + closedTag, upperText.ToUpper());
            }
            Console.WriteLine(text);

            //Variant 2
            //string str = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";

            //Console.WriteLine(Regex.Replace(str, "<upcase>(.*?)</upcase>", m => m.Groups[1].Value.ToUpper()));
        }
    }
}
