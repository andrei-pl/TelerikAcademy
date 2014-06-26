using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _06.SortStrings
{
    //Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file. Example:
	//Ivan			George
	//Peter			Ivan
	//Maria	   ->	Maria
	//George		Peter

    class SortStrings
    {
        static void Main(string[] args)
        {
            StreamReader file = new StreamReader(@"..\..\FileFortSort.txt");
            SortFile(file);
            StreamReader sortedFile = new StreamReader(@"..\..\SortedFile.txt");

            PrintFile(sortedFile);
        }

        private static void PrintFile(StreamReader file)
        {
            using (file)
            {
                string line = file.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = file.ReadLine();
                }
            }
        }

        private static void SortFile(StreamReader file)
        {
            StreamWriter sortedFile = new StreamWriter(@"..\..\SortedFile.txt");

            using (sortedFile)
            {
                using (file)
                {
                    List<string> names = new List<string>();
                   
                    string line = file.ReadLine();
                    while(line != null)
                    {
                        names.Add(line);
                        line = file.ReadLine();
                    }

                    names.Sort();

                    foreach (var element in names)
                    {
                        sortedFile.WriteLine(element);
                    }
                }
            }
        }
    }
}
