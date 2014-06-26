using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexVariable
{
    //Declare an integer variable and assign it with the value 254 in hexadecimal format. Use Windows Calculator to find its hexadecimal representation.

    class HexVariable
    {
        static void Main(string[] args)
        {
            int hex = 0xFE;
            Console.WriteLine("This is the number 254 in Hex format: {0:X0}", hex);
        }
    }
}
