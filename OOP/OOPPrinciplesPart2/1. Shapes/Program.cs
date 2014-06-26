using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape[] shapes = new Shape[3]
            {
                new Circle(3),
                new Triangle(2,3),
                new Rectangle(2,3)
            };

            Console.WriteLine("Circle surface: " + shapes[0].CalculateSurface());
            Console.WriteLine("Triangle surface: " + shapes[1].CalculateSurface());
            Console.WriteLine("Rectangle surface: " + shapes[2].CalculateSurface());

        }
    }
}
