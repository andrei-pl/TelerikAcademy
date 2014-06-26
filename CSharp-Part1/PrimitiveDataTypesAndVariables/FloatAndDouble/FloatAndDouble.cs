using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloatAndDouble
{
    class FloatAndDouble
    {
//Which of the following values can be assigned to a variable of type float and which to a variable of type double: 34.567839023, 12.345, 8923.1234857, 3456.091?

        static void Main(string[] args)
        {
            double double1 = 34.567839023d;     //double because it's more than 7 digits after decimal point
            float float1 = 12.345f;
            double double2 = 8923.1234857d;      //it's more than 7 digits after decimal point but the number is biger
            float float2 = 3456.091f;

            Console.WriteLine(double1 + ", " + float1 + ", " + double2 + ", " + float2);
        }
    }
}
