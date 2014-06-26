using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.SumOfNNumbers
{
    class SumOfNNumbers
    {
        //Write a program that gets a number n and after that gets more n numbers and calculates and prints their sum. 

        static void Main(string[] args)
        {
            Console.Write("How many numbers you want to sum? : ");
            int n = Int32.Parse(Console.ReadLine());

            double number = 0;
            double sum = 0;

            for (int i = 1; i <= n; i++)
            {
                Console.Write(i + ". : ");
                number = Double.Parse(Console.ReadLine());
                
                sum += number;
            }

            Console.WriteLine("The sum of all numbers is: " + sum);
        }
    }
}
