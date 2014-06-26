using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ExtensionSubstring
{
    //01. Implement an extension method Substring(int index, int length) for the class StringBuilder that returns new StringBuilder 
    //and has the same functionality as Substring in the class String.

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new StringBuilder("It's very nice day!").Substring(10, 8));
        }
    }
}
