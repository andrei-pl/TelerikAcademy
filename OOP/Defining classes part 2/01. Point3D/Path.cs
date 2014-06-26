using System;
using System.Collections;
using System.Collections.Generic;

namespace _01.Point3D
{
    class Path : IEnumerable<Point3D>
    {
        //4. Create a class Path to hold a sequence of points in the 3D space. 

        public List<Point3D> Points { get; private set; }

        public Path(params Point3D[] points)
        {
            Points = new List<Point3D>(points);
        }

        public void Add(Point3D point)
        {
            Points.Add(point);
        }

        public void Remove(Point3D point)
        {
            Points.Remove(point);
        }

        public override string ToString()
        {
            return String.Join(Environment.NewLine, Points);
        }

        public IEnumerator<Point3D> GetEnumerator()
        {
            foreach (Point3D point in Points)
                yield return point;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Point3D>)this).GetEnumerator();
        }
    }
}
