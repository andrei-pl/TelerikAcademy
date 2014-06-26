using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloatsCompare
{
    //Write a program that safely compares floating-point numbers with precision of 0.000001. Examples:(5.3 ; 6.01)  false;  (5.00000001 ; 5.00000003) -> true

    class FloatsCompare
    {
        static void Main(string[] args)
        {
            Console.Write("Type first float nuber: ");
            float a = float.Parse(Console.ReadLine());

            Console.Write("Type second float nuber: ");
            float b = float.Parse(Console.ReadLine());

            Console.WriteLine("Equal with precision of 0.000001: " + (a == b));
        }
    }
}
