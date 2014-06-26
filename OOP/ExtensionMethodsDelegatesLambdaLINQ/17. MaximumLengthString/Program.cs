using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17.MaximumLengthString
{
    class Program
    {
        //17. Write a program to return the string with maximum length from an array of strings. Use LINQ.

        static void Main(string[] args)
        {
            string[] array = {
                                 "some text",
                                 "another text",
                                 "some other text",
                                 "longest text in this array",
                                 "short text"
                             };

            var stringWithMaximalLength = array.Aggregate((max, current) => max.Length > current.Length ? max : current);

            Console.WriteLine(stringWithMaximalLength);
        }
    }
}
