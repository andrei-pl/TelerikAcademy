using System;
using System.IO;
using System.Text.RegularExpressions;

namespace _07._08.ReplaceSubstrings
{
    //Write a program that replaces all occurrences of the substring "start" with the substring "finish" in a text file. 
    //Ensure it will work with large files (e.g. 100 MB). 
    //Modify the solution of the previous problem to replace only whole words (not substrings).

    class ReplaceSubstrings
    {
        static void Main(string[] args)
        {
            StreamReader file = new StreamReader(@"..\..\Source.txt");
            StreamWriter replacedText = new StreamWriter(@"..\..\Replaced.txt");
            string line;

            while ((line = file.ReadLine()) != null)
            {
                //replacedText.WriteLine(line.ToLower().Replace("start", "finish"));            // exercise 7
                replacedText.WriteLine(Regex.Replace(line.ToLower(), @"\bstart\b", "finish"));  // exercise 8
            }
            file.Close();
            replacedText.Close();
            Console.WriteLine("New file is ready");
        }
    }
}
