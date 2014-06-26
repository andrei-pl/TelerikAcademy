using System;
using System.IO;

namespace _03.NumbersFrontOfLines
{
    //Write a program that reads a text file and inserts line numbers in front of each of its lines. The result should be written to another text file.

    class NumbersFrontOfLines
    {
        static void Main(string[] args)
        {
            StreamReader fileForRead = new StreamReader(@"..\..\NumbersFrontOfLines.cs");
            InputLinesWithIndex(fileForRead);
            Console.WriteLine("The final file is in .cs directory");
        }

        static void InputLinesWithIndex(StreamReader file)
        {
            StreamWriter final = new StreamWriter(@"..\..\final.txt");
            using (file)
            {
                string line = file.ReadLine();

                using (final)
                {
                    int count = 1;
                    while (line != null)
                    {
                        final.WriteLine(count + ". " + line);
                        line = file.ReadLine();
                        count++;
                    }
                }
            }
        }
    }
}
