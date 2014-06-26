using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquation
{
    class QuadraticEquation
    {
        //Write a program that enters the coefficients a, b and c of a quadratic equation: a*x2 + b*x + c = 0
		//and calculates and prints its real roots. Note that quadratic equations may have 0, 1 or 2 real roots.

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the coefficients a, b and c of a quadratic equation ax^2+bx+c=0 ");
            Console.Write("a = ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b = ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("c = ");
            double c = double.Parse(Console.ReadLine());

            double discriminant = (b * b) - (4 * a * c);
            double x1 = (-b + Math.Sqrt(discriminant)) / 2 * a;
            double x2 = (-b - Math.Sqrt(discriminant) )/ 2 * a;

            if (discriminant < 0)
            {
                Console.WriteLine("No real roots");
            }
            else if (discriminant == 0)
            {
                Console.WriteLine("There is one real root x1 = x2 = {0:F2}", x1);
            }
            else if (discriminant > 0)
            {
                Console.WriteLine("There are two real roots:");
                Console.WriteLine("x1 = {0:F2}", x1);
                Console.WriteLine("x2 = {0:F2}", x2);
            }
        }
    }
}
