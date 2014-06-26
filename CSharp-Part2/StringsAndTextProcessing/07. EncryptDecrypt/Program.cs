using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.EncryptDecrypt
{
    //Write a program that encodes and decodes a string using given encryption key (cipher). 
    //The key consists of a sequence of characters. The encoding/decoding is done by performing XOR (exclusive or) operation 
    //over the first letter of the string with the first of the key, the second – with the second, etc. 
    //When the last key character is reached, the next is the first.

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a word to encode: ");
            string word = Console.ReadLine();
            string cipher = "ab";

            Decrypt(Encrypt(word, cipher), cipher);
        }

        static string Encrypt(string word, string cipher)
        {
            StringBuilder encrypt = new StringBuilder();

            for (int i = 0; i < word.Length; i++)
            {
                encrypt.Append((char)(word[i] ^ cipher[i % cipher.Length]));
            }

            Console.WriteLine(encrypt.ToString());
            return encrypt.ToString();
        }

        static string Decrypt(string word, string cipher)
        {
            return Encrypt(word, cipher);
        }
    }
}
