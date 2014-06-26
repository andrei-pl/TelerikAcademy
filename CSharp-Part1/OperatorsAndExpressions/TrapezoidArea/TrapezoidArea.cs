using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrapezoidArea
{
    class TrapezoidArea
    {
        //Write an expression that calculates trapezoid's area by given sides a and b and height h.

        static void Main(string[] args)
        {
            Console.Write("Enter side \"a\" of the trapezoid: ");
            double sideA = Double.Parse(Console.ReadLine());

            Console.Write("Enter side \"b\" of the trapezoid: ");
            double sideB = Double.Parse(Console.ReadLine());

            Console.Write("Enter trapezoid height: ");
            double h = Double.Parse(Console.ReadLine());

            double area = (sideA + sideB) * h / 2;
            Console.WriteLine("The trapezoid's area is: " + area);
        }
    }
}
