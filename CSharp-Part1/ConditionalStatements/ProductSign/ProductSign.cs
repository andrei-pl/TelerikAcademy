using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSign
{
    class ProductSign
    {
        //Write a program that shows the sign (+ or -) of the product of three real numbers without calculating it. Use a sequence of if statements.

        static void Main(string[] args)
        {
            Console.Write("First product: ");
            float firstProduct = float.Parse(Console.ReadLine());
            Console.Write("Second product: ");
            float secondProduct = float.Parse(Console.ReadLine());
            Console.Write("Third product: ");
            float thirdProduct = float.Parse(Console.ReadLine());

            if (firstProduct == 0 || secondProduct == 0 || thirdProduct == 0)
            {
                Console.WriteLine("The product is zero");
            }

            else if (firstProduct > 0 && secondProduct > 0 && thirdProduct > 0)
            {
                Console.WriteLine("The sign is +");
            }
            else if (firstProduct < 0 && secondProduct < 0 && thirdProduct < 0)
            {
                Console.WriteLine("The sign is -");
            }
            else if (firstProduct < 0 && secondProduct < 0 && thirdProduct > 0)
            {
                Console.WriteLine("The sign is +");
            }
            else if (firstProduct < 0 && secondProduct > 0 && thirdProduct < 0)
            {
                Console.WriteLine("The sign is +");
            }
            else if (firstProduct > 0 && secondProduct < 0 && thirdProduct < 0)
            {
                Console.WriteLine("The sign is +");
            }
            else if (firstProduct > 0 && secondProduct > 0 && thirdProduct < 0)
            {
                Console.WriteLine("The sign is -");
            }
            else if (firstProduct > 0 && secondProduct < 0 && thirdProduct > 0)
            {
                Console.WriteLine("The sign is -");
            }
            else if (firstProduct < 0 && secondProduct > 0 && thirdProduct > 0)
            {
                Console.WriteLine("The sign is -");
            }
        }
    }
}
