using System;
using System.IO;

namespace _02.ConcatTwoFiles
{
    //Write a program that concatenates two text files into another text file.

    class ConcatTwoFiles
    {
        static void Main(string[] args)
        {
            StreamReader firstFile = new StreamReader(@"First.txt");
            StreamReader secondFile = new StreamReader(@"Second.txt");
            using (firstFile)
            {
                using (secondFile)
                {
                    MakeConcatenatedFile(firstFile, secondFile);
                }
            }

            Console.WriteLine("Your file is ready! Check your cs. directory!");
        }

        static void MakeConcatenatedFile(StreamReader first, StreamReader second)
        {
            StreamWriter finalFile = new StreamWriter(@"..\..\Concatenated.txt");

            string firstFileText = first.ReadToEnd();
            string secondFileText = second.ReadToEnd();

            using (finalFile)
            {
                finalFile.WriteLine(firstFileText + Environment.NewLine + secondFileText);
            }
        }
    }
}
