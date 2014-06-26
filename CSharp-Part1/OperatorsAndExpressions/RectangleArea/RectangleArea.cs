using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleArea
{
    class RectangleArea
    {
        static void Main(string[] args)
        {
            //Write an expression that calculates rectangle’s area by given width and height.

            Console.Write("Enter positive number for rectangle's width: ");
            double width = Double.Parse(Console.ReadLine());

            Console.Write("Enter positive number for rectangle's height: ");
            double height = Double.Parse(Console.ReadLine());

            double rectArea = width * height;

            Console.WriteLine("The recatngle's area is: " + rectArea);

        }
    }
}
