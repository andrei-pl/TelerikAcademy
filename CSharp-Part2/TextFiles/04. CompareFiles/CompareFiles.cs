using System;
using System.IO;
using System.Linq;
using System.Text;

namespace _04.CompareFiles
{
    //Write a program that compares two text files line by line and prints the number of lines that are the same and the number of lines that are different. 
    //Assume the files have equal number of lines.

    class CompareFiles
    {
        static void Main(string[] args)
        {
            StreamReader firstFile = new StreamReader(@"..\..\FirstFile.txt");
            StreamReader secondFile = new StreamReader(@"..\..\SecondFile.txt");
            using (firstFile)
            {
                using (secondFile)
                {
                    CompFiles(firstFile, secondFile);
                }
            }
        }

        static void CompFiles(StreamReader first, StreamReader second)
        {
            string firstFileLine = first.ReadLine();
            string secondFileLine = second.ReadLine();

            int sameLinesCounter = 0;
            int differentLinesCounter = 0;

            while (firstFileLine != null && secondFileLine != null)
            {
                if (firstFileLine.Equals(secondFileLine))
                {
                    sameLinesCounter++;
                }
                else
                {
                    differentLinesCounter++;
                }
                firstFileLine = first.ReadLine();
                secondFileLine = second.ReadLine();
            }
            Console.WriteLine("{0} equal lines and {1} different lines", sameLinesCounter, differentLinesCounter);
        }
    }
}
