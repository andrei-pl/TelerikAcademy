using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointWithinCircleOutRectangle
{
    //Write an expression that checks for given point (x, y) if it is within the circle K( (1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2).

    class PointWithinCircleOutRectangle
    {
        static void Main(string[] args)
        {
            Console.Write("Enter point for X: ");
            double pointX = Double.Parse(Console.ReadLine());

            Console.Write("Enter point for Y: ");
            double pointY = Double.Parse(Console.ReadLine());

            double centreX = 1;
            double centreY = 1;

            double radius = 3;

            if ((pointX - centreX) * (pointX - centreX) + (pointY - centreY) * (pointY - centreY) <= radius * radius)
            {
                Console.Write("Point with coordinates (" + pointX + ", " + pointY + ") is within the circle K((1,1),3) ");
            }
            else
            {
                Console.Write("Point with coordinates (" + pointX + ", " + pointY + ") is outside the circle K((1,1),3) ");
            }
            if (pointX > 5 || pointX < -1 || pointY > 1 || pointY < -1)
            {
                Console.WriteLine("and out of the rectangle R(top=1, left = -1, width = 6, height = 2).");
            }
            else
            {
                Console.WriteLine("and in the rectangle R(top=1, left = -1, width = 6, height = 2).");
            }

        }
    }
}
