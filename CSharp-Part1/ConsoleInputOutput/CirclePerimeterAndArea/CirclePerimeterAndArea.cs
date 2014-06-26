using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirclePerimeterAndArea
{
    //Write a program that reads the radius r of a circle and prints its perimeter and area.

    class CirclePerimeterAndArea
    {
        static void Main(string[] args)
        {
            Console.Write("Enter value for circle radius: ");
            double radius = Double.Parse(Console.ReadLine());
            
            Console.WriteLine("The perimeter of this circle is: {0:0.00}",  2 * Math.PI * radius);
            Console.WriteLine("The area of this circle is: {0:0.00}", Math.PI * Math.Pow(radius, 2));
        }
    }
}
