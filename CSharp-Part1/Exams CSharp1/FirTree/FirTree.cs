using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirTree
{
    class FirTree
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int width = 2 * n - 3;
            int a = width / 2;
            int b = a;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if ((i == 0 || i == n - 1) && j == width / 2)
                    {
                        Console.Write("*");
                    }
                    else if (j >= a && j <= b && i < n - 1)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                a--;
                b++;

                Console.WriteLine();
            }
            // Read the input   //The original solution
            //int N = int.Parse(Console.ReadLine());

            //// Write the tree
            //for (int i = 0; i < N - 1; i++)
            //{
            //    string dots = new String('.', (N - i) - 2);
            //    string stars = new String('*', (i * 2) + 1);
            //    Console.Write(dots);
            //    Console.Write(stars);
            //    Console.Write(dots);
            //    Console.WriteLine();
            //}

            //// Write the stem
            //string finalDots = new string('.', N - 2);
            //Console.Write(finalDots);
            //Console.Write("*");
            //Console.Write(finalDots);
            //Console.WriteLine();
        }
    }
}
