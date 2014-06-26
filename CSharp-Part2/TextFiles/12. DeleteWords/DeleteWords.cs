using System;
using System.IO;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;

namespace _12.DeleteWords
{
    //Write a program that removes from a text file all words listed in given another text file. Handle all possible exceptions in your methods.

    class DeleteWords
    {
        static void Main(string[] args)
        {
            DeleteWordsFromFile(@"..\..\words.txt", @"..\..\input.txt");
        }

        private static void DeleteWordsFromFile(string wordsFile, string file)
        {
            string regex = @"\b(\w" + String.Join("|", File.ReadAllLines(wordsFile)) + @")\b";

            try
            {
                using (StreamReader input = new StreamReader(file, Encoding.GetEncoding("windows-1251")))
                {
                    using (StreamWriter fileResult = new StreamWriter(@"..\..\result.txt", false, Encoding.GetEncoding("windows-1251")))
                    {
                        string line;
                        while ((line = input.ReadLine()) != null)
                        {
                            fileResult.WriteLine(Regex.Replace(line.ToLower(), regex, String.Empty).Trim());
                        }
                    }
                }
                Console.WriteLine("Your new fail is ready. Check .cs directory!");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SecurityException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
