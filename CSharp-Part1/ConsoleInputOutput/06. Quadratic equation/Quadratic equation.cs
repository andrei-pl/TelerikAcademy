using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Quadratic_equation
{
    class Program
    {
        //Write a program that reads the coefficients a, b and c of a quadratic equation ax2+bx+c=0 and solves it (prints its real roots).

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the coefficients a, b and c of a quadratic equation ax^2+bx+c=0 ");
            Console.Write("a = ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b = ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("c = ");
            double c = double.Parse(Console.ReadLine());

            double x1 = (-b + Math.Sqrt(b * b - 4 * a * c)) / 2 * a;
            double x2 = (-b - Math.Sqrt(b * b - 4 * a * c)) / 2 * a;

            Console.WriteLine();
            Console.WriteLine("Solution of the equation");
            Console.WriteLine("x1 = {0:F2}", x1);
            Console.WriteLine("x2 = {0:F2}", x2);
        }
    }
}
