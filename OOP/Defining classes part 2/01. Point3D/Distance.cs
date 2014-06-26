using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Point3D
{
    static class Distance
    {
        //3. Write a static class with a static method to calculate the distance between two points in the 3D space.

        public static double CalculateDistance(Point3D point1, Point3D point2)
        {
            return Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2) + Math.Pow(point1.Z - point2.Z, 2));
        }
    }
}
