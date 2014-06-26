using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Shapes
{
    class Circle : Shape
    {
        public Circle(double diameter)
        {
            Width = Height = diameter;
        }

        public override double CalculateSurface()
        {
            return Math.PI * Math.Pow(Width / 2, 2);
        }
    }
}
