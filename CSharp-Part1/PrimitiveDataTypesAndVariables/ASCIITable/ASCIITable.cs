using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIITable
{
    //Find online more information about ASCII (American Standard Code for Information Interchange) and write a program that 
    //prints the entire ASCII table of characters on the console.

    class ASCIITable
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 128; i++)
            {
                Console.WriteLine("character {0} = {1}", i, (char)i);
            }
        }
    }
}
