using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractBitValue
{
    //Write an expression that extracts from a given integer i the value of a given bit number b. Example: i=5; b=2  value=1.

    class ExtractBitValue
    {
        static void Main(string[] args)
        {

            Console.Write("Enter number: ");
            int v = Int32.Parse(Console.ReadLine());

            Console.Write("Enter which bit you want to check (counting from 0): ");
            int p = Int32.Parse(Console.ReadLine());

            int mask = 1 << p;
            int bitValue = v & mask;
            bitValue = bitValue >> p;

            Console.WriteLine("bit " + p + " has value " + bitValue);
        }
    }
}
