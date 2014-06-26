using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitvalueAtPosition
{
    //Write a boolean expression that returns if the bit at position p (counting from 0) in a given integer number v has value of 1. Example: v=5; p=1  false.

    class BitValueAtPosition
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number: ");
            int v = Int32.Parse(Console.ReadLine());

            Console.Write("Enter which bit you want to check: ");
            int p = Int32.Parse(Console.ReadLine());

            Console.WriteLine("False meens that the bit has value \"0\", and true - \"1\"");

            int mask = 1 << p;
            int bitValue = v & mask;
            bitValue = bitValue >> p;

            bool isTrue = (bitValue > 0) ? true : false;

            Console.WriteLine(isTrue);
        }
    }
}
