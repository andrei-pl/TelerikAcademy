using System;
using System.Text;

namespace _02.ReverseString
{
    //Write a program that reads a string, reverses it and prints the result at the console. Example: "sample" -> "elpmas".

    class ReverseString
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter some text to reverse it: ");
            char[] text = Console.ReadLine().ToCharArray();

            Array.Reverse(text);

            Console.WriteLine(text);

            //Variant 2
            //string text = Console.ReadLine();

            //StringBuilder reversedString = new StringBuilder();
            //for (int i = text.Length - 1; i >= 0; i--)
            //{
            //    reversedString.Append(text[i]);
            //}
        }
    }
}
