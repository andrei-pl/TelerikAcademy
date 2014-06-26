using System;
using System.Text;
using System.IO;

namespace _10.TextWithoutTags
{
    //Write a program that extracts from given XML file all the text without the tags. Example:
    //<?xml version="1.0"><student><name>Pesho</name><age>21</age><interests count="3">
    //<interest> Games</instrest><interest>C#</instrest><interest> Java</instrest></interests></student>

    class TextWithoutTags
    {
        static void Main(string[] args)
        {
            var source = new StreamReader(@"..\..\input.txt");
            Console.WriteLine(WithoutTags(source).Trim());
        }

        private static string WithoutTags(StreamReader file)
        {
            var text = new StringBuilder();
            bool isOpenTag = false;

            using (file)
            {
                string line;
                while((line = file.ReadLine() ) != null)
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (line[i] == '<')
                        {
                            if (text.Length > 0 && i > 0 && line[i - 1] != '>')
                            {
                                text.AppendLine();
                            }
                            isOpenTag = true;
                        } 
                        if (isOpenTag == false)
                        {
                            text.Append(line[i]);
                        }
                        if (line[i] == '>')
                        {
                            isOpenTag = false;
                        }
                    }
                }
            }
            return text.ToString();
        }
    }
}
