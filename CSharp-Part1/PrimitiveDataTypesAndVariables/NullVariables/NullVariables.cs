using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullVariables
{
    class NullVariables
    {
        //Create a program that assigns null values to an integer and to double variables. 
        //Try to print them on the console, try to add some values or the null literal to them and see the result.

        static void Main(string[] args)
        {
            int? intValue = null;
            double? doubleValue = null;

            Console.WriteLine("Integer value is: {0} \nDouble value is {1}", intValue, doubleValue);

            intValue += null;
            doubleValue += 2.5; //Adding values to null is always null
            Console.WriteLine("Integer value is: {0} \nDouble value is {1}", intValue, doubleValue);
        }
    }
}
