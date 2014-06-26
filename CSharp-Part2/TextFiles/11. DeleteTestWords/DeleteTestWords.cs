using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;


namespace _11.DeleteTestWords
{
    //Write a program that deletes from a text file all words that start with the prefix "test". Words contain only the symbols 0...9, a...z, A…Z, _.

    class DeleteTestWords
    {
        static void Main(string[] args)
        {
            using (StreamReader input = new StreamReader("../../input.txt", Encoding.GetEncoding("windows-1251")))
            {
                using (StreamWriter output = new StreamWriter("../../output.txt", false, Encoding.GetEncoding("windows-1251")))
                {
                    string line;
                    while ((line = input.ReadLine()) != null)
                    {
                        output.WriteLine(Regex.Replace(line.ToLower(), @"\btest\w*\b", String.Empty));
                    }
                }
            }
            Console.WriteLine("New file is created. Check yoour .cs directory");
        }
    }
}
