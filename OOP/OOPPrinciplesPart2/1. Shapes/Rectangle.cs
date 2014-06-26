using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Shapes
{
    class Rectangle : Shape
    {
         public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override double CalculateSurface()
        {
            return Width * Height;
        }
    }
}
