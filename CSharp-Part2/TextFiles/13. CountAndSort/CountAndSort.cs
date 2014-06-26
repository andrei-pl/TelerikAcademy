using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security;

namespace _13.CountAndSort
{
    //Write a program that reads a list of words from a file words.txt and finds how many times each of the words is contained in another file test.txt. 
    //The result should be written in the file result.txt and the words should be sorted by the number of their occurrences in descending order. 
    //Handle all possible exceptions in your methods.

    class CountAndSort
    {
        static void Main(string[] args)
        {
            CountAndSortMatchingWords(@"..\..\words.txt", @"..\..\input.txt");
        }

        private static void CountAndSortMatchingWords(string wordsFile, string inputFile)
        {

            try
            {
                using (StreamReader file = new StreamReader(inputFile, Encoding.GetEncoding("windows-1251")))
                {
                    using (StreamReader words = new StreamReader(wordsFile, Encoding.GetEncoding("windows-1251")))
                    {
                        List<string> wordsList = new List<string>(File.ReadAllLines(wordsFile));

                        List<string> fileArray = new List<string>(file.ReadToEnd().ToLower().Split(new string[] { " ", "\n", "\r", ".", ",", "–", "!" },
                            StringSplitOptions.RemoveEmptyEntries));

                        using (StreamWriter fileResult = new StreamWriter(@"..\..\result.txt", false, Encoding.GetEncoding("windows-1251")))
                        {
                            List<string> countingWords = new List<string>();
                            foreach (var element in wordsList)
                            {
                                int count = 0;
                                int index = fileArray.IndexOf(element, 0);
                                while (index != -1 && index < fileArray.Count)
                                {
                                    count++;
                                    index = fileArray.IndexOf(element, index + 1);
                                }

                                countingWords.Add(count + " times " + element);
                            }
                            countingWords.Sort((x, y) => y.CompareTo(x));

                            foreach (var element in countingWords)
                            {
                                fileResult.WriteLine(element);
                            }
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
