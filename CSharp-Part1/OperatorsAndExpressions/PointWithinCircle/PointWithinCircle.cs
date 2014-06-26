using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointWithinCircle
{
    class PointWithinCircle
    {
        //Write an expression that checks if given point (x,  y) is within a circle K(O, 5).

        static void Main(string[] args)
        {
            Console.Write("Enter point for X: ");
            double pointX = Double.Parse(Console.ReadLine());

            Console.Write("Enter point for Y: ");
            double pointY = Double.Parse(Console.ReadLine());

            double radius = 5;

            if (pointX * pointX + pointY * pointY <= radius * radius)
            {
                Console.WriteLine("Point with coordinates (" + pointX + ", " + pointY + ") is within the circle K(0,5).");
            }
            else
            {
                Console.WriteLine("Point with coordinates (" + pointX + ", " + pointY + ") is outside the circle K(0,5).");
            }
            

        }
    }
}
