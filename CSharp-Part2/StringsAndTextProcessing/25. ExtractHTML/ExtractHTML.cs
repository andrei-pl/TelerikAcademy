using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _25.ExtractHTML
{
    //Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags. Example:
    //<html>
    //  <head><title>News</title></head>
    //  <body><p><a href="http://academy.telerik.com">Telerik
    //    Academy</a>aims to provide free real-world practical
    //    training for young people who want to turn into
    //    skillful .NET software engineers.</p></body>
    //</html>

    class ExtractHTML
    {
        static void Main(string[] args)
        {
            string tag = "<html><head><title>News</title></head><body><p><a href=\"http://academy.telerik.com\">Telerik Academy</a>aims to provide free real-world practical training for young people who want to turn into skillful .NET software engineers.</p></body></html>";

            StringBuilder withoutTags = new StringBuilder();

            bool openTag = false;

            for (int i = 0; i < tag.Length; i++)
            {
                if (tag[i] == '<')
                {
                    openTag = true;
                }
                if (openTag == false)
                {
                    withoutTags.Append(tag[i]);
                    if (((i + 1) < tag.Length - 1) && (tag[i + 1] == '<'))
                    {
                        withoutTags.AppendLine();
                    }
                }
                if (tag[i] == '>')
                {
                    openTag = false;
                }
            }
            Console.WriteLine((withoutTags.ToString()).Trim());

            //Variqant 2
            //foreach (Match text in Regex.Matches(tag, "(?<=>).*?(?=<)"))
            //    if (!String.IsNullOrWhiteSpace(text.Value)) Console.WriteLine(text);
        }
    }
}
