using System;
using System.Collections.Generic;
using System.IO;

namespace _09.DeleteOddLines
{
    //Write a program that deletes from given text file all odd lines. The result should be in the same file.

    class DeleteOddLines
    {
        static void Main(string[] args)
        {
            List<string> lines = new List<string>();

            ReadEvenLines(lines);

            WriteEvenLines(lines);

            Console.WriteLine("File is updated! Check your .cs directory");
        }

        private static void ReadEvenLines(List<string> lines)
        {
            using (var fRead = new StreamReader(@"..\..\source.txt"))
            {
                int countLines = 1;
                string line;
                while ((line = fRead.ReadLine()) != null)
                {
                    if (countLines % 2 == 0)
                    {
                        lines.Add(line);
                    }
                    countLines++;
                }
            }
        }

        private static void WriteEvenLines(List<string> lines)
        {
            using (var fWrite = new StreamWriter(@"..\..\source.txt"))
            {
                foreach (var element in lines)
                {
                    fWrite.WriteLine(element);
                }
            }
        }
    }
}