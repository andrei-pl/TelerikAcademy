using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Point3D
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing distance");
            Console.WriteLine("Distance: {0}", Distance.CalculateDistance(new Point3D(1, 1, 1), Point3D.O));
            Console.WriteLine();

            Console.WriteLine("Testing path");

            Path path = new Path(new Point3D(1, 1, 1), new Point3D(1, 2, 1), new Point3D(1, 3, 1));
            Console.WriteLine(path);
            Console.WriteLine();

            Console.WriteLine("Testing add/remove");
            path.Add(new Point3D(1, 2, 4));
            path.Remove(new Point3D(1, 2, 1));

            Console.WriteLine(path.ToString());
            Console.WriteLine();

            Console.WriteLine("Testing path storage");

            PathStorage.Save(path, "../../input.txt");
            Console.WriteLine(PathStorage.Load("../../input.txt"));
        }
    }
}
