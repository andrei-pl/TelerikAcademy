using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.SpiralMatrix
{
    class SpiralMatrix
    {
//Write a program that reads a positive integer number N (N < 20) from console and outputs in the console the numbers 1 ... N numbers arranged as a spiral.
//		Example for N = 4
//                1  2  3  4
//               12 13 14  5
//               11 16 15  6 
//               10  9  8  7
        static void Main(string[] args)
        {
            Console.Write("Enter array length (N < 20): ");
            int n = Int32.Parse(Console.ReadLine());

            if (n > 0 && n < 20)
            {
                int[,] arr = new int[n, n];

                int counter = 1;

                int start = 0;
                int end = n - 1;
              
                while (counter <= (n * n))
                {

                    for (int i = start; i <= end; i++)
                    {
                        arr[start, i] = counter++;
                    }
                    for (int j = start + 1; j <= end; j++)
                    {
                        arr[j, end] = counter++;
                    }
                    for (int i = end - 1; i >= start; i--)
                    {
                        arr[end, i] = counter++;
                    }
                    for (int j = end - 1; j > start; j--)
                    {
                        arr[j, start] = counter++;
                    }

                    start ++;
                    end --;
                   
                }

                for (int a = 0; a < n; a++)
                {
                    for (int b = 0; b < n; b++)
                    {
                        if (n > 3)
                        {
                            if (n < 11)
                            {
                                if (arr[a, b] < 10)
                                {
                                    Console.Write(" ");       //This spaces are only to have correct painted matrix
                                }
                                Console.Write(arr[a, b] + " ");   
                            }
                            else
                            {
                                if (arr[a, b] < 10)
                                {
                                    Console.Write("  ");
                                }
                                if (arr[a, b] >= 10 && arr[a, b] < 100)
                                {
                                    Console.Write(" ");
                                }
                                Console.Write(arr[a, b] + " ");
                            }
                        }
                        else
                        {
                            Console.Write(arr[a, b] + " "); //Otherwise, if they were not more extra spacing, the condition of painting would be only this row
                        }                                   //but it not look naturaly
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
