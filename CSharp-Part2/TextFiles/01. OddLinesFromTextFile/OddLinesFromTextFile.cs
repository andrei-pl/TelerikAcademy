using System;
using System.IO;

namespace _01.OddLinesFromTextFile
{
    //Write a program that reads a text file and prints on the console its odd lines.

    class OddLinesFromTextFile
    {
        static void Main(string[] args)
        {
            //StreamReader file = new StreamReader(@"..\..\OddLinesFromTextFile.cs");
            StreamReader file = new StreamReader(@"Test.txt");
            PrintOddLines(file);
        }

        static void PrintOddLines(StreamReader reader)
        {
            using (reader)
            {
                int lineNumber = 0;
                string line = reader.ReadLine();

                while (line != null)
                {
                    lineNumber++;
                    if (lineNumber % 2 != 0)
                    {
                        Console.WriteLine(lineNumber + ". " + line);
                    }

                    line = reader.ReadLine();
                }
            }
        }
    }
}
