using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.EuclideanGCD
{
    //Write a program that calculates the greatest common divisor (GCD) of given two numbers. Use the Euclidean algorithm (find it in Internet).

    class EuclideanGCD
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first integer:");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second integer:");
            int b = int.Parse(Console.ReadLine());

            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }
            Console.WriteLine("The greatest common divisor by Eucliddean algorithm is:");
            if (a == 0)
                Console.WriteLine(b);
            else
                Console.WriteLine(a);
        }
    }
}
