using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Fibonacci
{
    //Write a program to print the first 100 members of the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …

    class Fibonacci
    {
        static void Main(string[] args)
        {
            ulong prev = 0L;
            ulong curr = 1L;
            ulong sum = prev + curr;

            Console.WriteLine("1. " + prev);
            Console.WriteLine("2. " + curr);
            for (int i = 3; i <= 100; i++)
            {
                if (i < 95)
                {
                    sum = prev + curr;
                    prev = curr;
                    curr = sum; 
                    Console.WriteLine((i) + ". " + sum);
                }
                else
                {
                    if (i == 95)           //when the index becomes 95, the number goes beyond range and needs to divide by 100 to calculate correctly
                    {
                        prev /= 100;
                        curr /= 100;
                        sum /= 100;
                    }
                    sum = prev + curr;
                    prev = curr;
                    curr = sum;
                    Console.WriteLine((i) + ". " + sum + "E+2");
                }
            }
            Console.WriteLine();
        }
    }
}
