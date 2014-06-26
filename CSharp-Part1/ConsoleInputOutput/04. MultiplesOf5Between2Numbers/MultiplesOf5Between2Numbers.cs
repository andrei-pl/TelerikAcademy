using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.MultiplesOf5Between2Numbers
{
    class MultiplesOf5Between2Numbers
    {
        static void Main(string[] args)
        {
            //Write a program that reads two positive integer numbers and prints how many numbers p exist between them 
            //such that the reminder of the division by 5 is 0 (inclusive). Example: p(17,25) = 2.

            Console.Write("Enter first number (positive): ");
            uint firstNumber = UInt32.Parse(Console.ReadLine());
            Console.Write("Enter second number (positive): ");
            uint secondNumber = UInt32.Parse(Console.ReadLine());

            uint min;
            uint max;
            if (firstNumber < secondNumber)     //check which number is greater to can make compare easily
            {
                min = firstNumber;
                max = secondNumber;
            }
            else
            {
                min = secondNumber;
                max = firstNumber;
            }
            int count = 0;
            for (uint i = min; i <= max; i++)
            {
                if ((i % 5) == 0)                       //check which number is divided by 5
                {
                    count++;
                }
            }
            Console.WriteLine("There are " + count + " numbers between " + min + " and " + max + " which the reminder of the division by 5 is 0 (inclusive)." );
        }
    }
}
