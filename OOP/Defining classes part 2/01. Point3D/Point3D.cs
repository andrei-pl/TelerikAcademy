using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Point3D
{
    struct Point3D
    {
        //1. Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space. Implement the ToString() to enable printing a 3D point.
        private static readonly string separator = " ";

        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }

            //2. Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}.
            //Add a static property to return the point O.

        private static readonly Point3D o = new Point3D(0, 0, 0);
        public static Point3D O { get { return o; } }

        public Point3D(double x, double y, double z) : this()
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return String.Join(separator, X, Y, Z);
        }
    }
}
