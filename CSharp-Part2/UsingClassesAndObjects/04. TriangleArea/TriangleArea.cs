using System;

namespace _04.TriangleArea
{
    //Write methods that calculate the surface of a triangle by given:
    //Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math.

    class TriangleArea
    {
        static double GetArea(double a, double h)
        {
            return (a * h) / 2;
        }

        static double GetArea(double a, double b, double c)
        {
            double p = (a + b + c) / 2;

            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        static double GetArea(double a, double b, int alpha)
        {
            return (a * b * Math.Sin(Math.PI * alpha / 180)) / 2;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Calculating the surface of a triangle: ");
            Console.WriteLine("1. by side and an altitude ");
            Console.WriteLine("2. by 3 sides");
            Console.WriteLine("3. by 2 sides and an angle between them(in degrees)");
            Console.WriteLine("Choose from 1 to 3.");
            int choice = int.Parse(Console.ReadLine());
            double a;
            double b;
            double c;
            int alpha;
            double area;

            if (choice == 1)
            {
                Console.Write("Enter side: ");
                a = double.Parse(Console.ReadLine());
                Console.Write("Enter altitude: ");
                b = double.Parse(Console.ReadLine());
                area = GetArea(a, b);
                Console.WriteLine("The area is: {0}", area);
            }
            else if (choice == 2)
            {
                Console.Write("Enter side \"a\": ");
                a = double.Parse(Console.ReadLine());
                Console.Write("Enter side \"b\": ");
                b = double.Parse(Console.ReadLine());
                Console.Write("Enter side \"c\": ");
                c = double.Parse(Console.ReadLine());
                area = GetArea(a, b, c);
                Console.WriteLine("The area is: {0}", area);
            }
            else if (choice == 3)
            {
                Console.Write("Enter side \"a\": ");
                a = double.Parse(Console.ReadLine());
                Console.Write("Enter side \"b\": ");
                b = double.Parse(Console.ReadLine());
                Console.Write("Enter angle: ");
                alpha = int.Parse(Console.ReadLine());
                area = GetArea(a, b, alpha);
                Console.WriteLine("The area is: {0}", area);
            }
            else
            {
                Console.WriteLine("Invalid choice!");
            }
        }
    }
}
