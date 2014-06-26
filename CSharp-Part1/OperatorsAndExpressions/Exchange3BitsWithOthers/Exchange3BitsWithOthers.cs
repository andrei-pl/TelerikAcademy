using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange3BitsWithOthers
{
    //Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.

    class Exchange3BitsWithOthers
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number: ");
            uint number = UInt32.Parse(Console.ReadLine());
            Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));

            uint mask1 = 7 << 3;
            uint getValue1 = number & mask1;
            getValue1 = getValue1 >> 3;

            uint mask2 = 7 << 24;
            uint getValue2 = number & mask2;
            getValue2 = getValue2 >> 24;

            number = (number & ~mask1) & ~mask2;
            number = (number | (getValue1 << 24)) | (getValue2 << 3);

            Console.WriteLine(number);
            Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));
            
        }
    }
}
