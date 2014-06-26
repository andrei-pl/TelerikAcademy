using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.FindMax
{
    class FindMax
    {
        //Write a program that finds the biggest of three integers using nested if statements.

        static void Main(string[] args)
        {
            Console.Write("First integer: ");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.Write("Second integer: ");
            int secondNumber = int.Parse(Console.ReadLine());
            Console.Write("Third integer: ");
            int thirdNumber = int.Parse(Console.ReadLine());

            int max = firstNumber;
            if (firstNumber < secondNumber)
            {
                max = secondNumber;
                if (max < thirdNumber)
                {
                    max = thirdNumber;
                }
            } 
            else if (max < thirdNumber)
            {
                max = thirdNumber;
            }
            Console.WriteLine("The bigest integer is: " + max);
        }
    }
}
