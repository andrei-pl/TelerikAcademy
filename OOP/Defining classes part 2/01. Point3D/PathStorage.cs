using System;
using System.IO;
using System.Linq;

namespace _01.Point3D
{
    static class PathStorage
    {
        //4. Create a static class PathStorage with static methods to save and load paths from a text file. Use a file format of your choice.

        public static Path Load(string file)
        {
            if (String.IsNullOrWhiteSpace(file)) 
            {
                throw new ArgumentException("File name cannot be null or empty.");
            }

            if (!File.Exists(file))
            {
                throw new ArgumentException("The specified file doesn't exist in the local file system.");
            }

            Path points = new Path();

            using (StreamReader fileReader = new StreamReader(file))
            {
                string line;
                while ((line = fileReader.ReadLine()) != null)
                {
                    string[] coordinates = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    double x, y, z;
                    if (coordinates.Length == 3 &&
                        Double.TryParse(coordinates[0], out x) && Double.TryParse(coordinates[1], out y) && Double.TryParse(coordinates[2], out z))
                    {
                        Point3D point = new Point3D(x, y, z);
                        points.Add(point);
                    }
                }
            }

            return points;
        }

        public static void Save(Path path, string file)
        {
            using (StreamWriter source = new StreamWriter(file))
            {
                if (String.IsNullOrWhiteSpace(file))
                {
                    throw new ArgumentException("File name cannot be null or empty.");
                }

                foreach (Point3D point in path)
                {
                    source.WriteLine(point);
                }
            }
        }
    }
}
