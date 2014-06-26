using System;
using System.Text;

namespace _10.UnicodeConvert
{
    //Write a program that converts a string to a sequence of C# Unicode character literals. Use format strings. Sample input:
    //Hi!
    //Expected output: \u0048\u0069\u0021

    class UnicodeConvert
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter some text");
            string text = Console.ReadLine();
            StringBuilder unicode = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                unicode.AppendFormat(@"\u{0:X4}", (int)text[i]);
            }
            Console.WriteLine(unicode.ToString());
        }
    }
}
