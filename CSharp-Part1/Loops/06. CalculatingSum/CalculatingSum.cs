using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.CalculatingSum
{
    //Write a program that, for a given two integer numbers N and X, calculates the sumS = 1 + 1!/X + 2!/X^2 + ... + N!/X^N

    class CalculatingSum
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter integer for N : ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter integer for X : ");
            int x = int.Parse(Console.ReadLine());

            ulong factN = 1;
            double sqrX = 1;
            double sum = 1;
            
            if (n > 1 && x != 0)
            {
                for (int i = 1; i <= n; i++)
                {
                    factN *= (ulong)i;
               
                    sqrX = Math.Pow(x, i);

                    sum += factN / sqrX;
                }

                Console.WriteLine("The sum \"1 + 1!/X + 2!/X^2 + ... + N!/X^N\" is: {0:F2} ", sum);
            }
            else
            {
                Console.WriteLine("Invalid numbers!");
            }
        }
    }
}
