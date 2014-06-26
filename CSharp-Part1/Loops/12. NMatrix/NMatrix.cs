using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.NMatrix
{
    //Write a program that reads from the console a positive integer number N (N < 20) and outputs a matrix like the following:
    //
	//  N = 3			N = 4
    //  1 2 3          1 2 3 4  
    //  2 3 4          2 3 4 5
    //  3 4 5          3 4 5 6
    //                 4 5 6 7

    class NMatrix
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter positive number for the size of the matrix: ");
            int n = int.Parse(Console.ReadLine());

            if (n > 0)
            {
                for (int col = 0; col < n; col++)
                {
                    for (int row = 0; row < n; row++)
                    {
                        Console.Write((col + row + 1) + " ");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Invalid number!");
            }
        }
    }
}
