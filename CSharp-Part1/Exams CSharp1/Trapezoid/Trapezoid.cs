using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trapezoid
{
    class Trapezoid
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.Write(new string('.', n));
            Console.WriteLine(new string('*', n));
            for (int i = 1; i < n; i++)
            {
                Console.Write(new string('.', n - i));
                Console.Write("*");
                Console.Write(new string('.', (n - 2) + i));
                Console.WriteLine("*");
            }
            Console.WriteLine(new string('*', 2 * n));
        }
    }
}
