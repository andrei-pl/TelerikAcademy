using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueOnBit3
{
    class ValueOnBit3
    {
        //Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.

        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int number = Int32.Parse(Console.ReadLine());

            int p = 3;
            int mask = 1 << p;

            int compare = number & mask;
            int bit = compare >> p;

            Console.WriteLine("bit 3 is " + bit);
        } 
    }
}