using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.IndexOfEachLetter
{
    //Write a program that creates an array containing all letters from the alphabet (A-Z). 
    //Read a word from the console and print the index of each of its letters in the array.

    class IndexOfEachLetter
    {
        static void Main(string[] args)
        {
            char[] alphabet = new char[26];

            for (int i = 'A'; i <= 'Z'; i++)
            {
                alphabet[i - 'A'] = (char)i;
            }

            string word = Console.ReadLine();

            int result = 0;

            for (int i = 0; i < word.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (word[i] == alphabet[j])
                    {
                        result = word[i] - 'A' + 1;
                        Console.WriteLine("Index of letter {0} is : {1}", word[i], result);
                    }
                }
            }
        }
    }
}
