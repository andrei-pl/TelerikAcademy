using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariablesDeclaring
{
    //Declare five variables choosing for each of them the most appropriate of the types byte, sbyte, short, ushort, int, uint, long, ulong 
    //to represent the following values: 52130, -115, 4825932, 97, -10000.

    class DeclaringVariables
    {
        static void Main(string[] args)
        {
            byte byteVariable = 97;             //for area from 0 to 225
            sbyte sbyteVariable = -115;         //for area from -128 to 127  
            short shortVariable = -10000;       //for area from -32 768 to 32 767
            ushort ushortVariable = 52130;      //for area from 0 to 65 535
            int intVariable = 4825932;          //for area from -2 147 483 648 to 2 147 483 647

            Console.WriteLine(byteVariable + ", " + sbyteVariable + ", " + shortVariable + ", " + ushortVariable + ", " + intVariable);
        }
    }
}
