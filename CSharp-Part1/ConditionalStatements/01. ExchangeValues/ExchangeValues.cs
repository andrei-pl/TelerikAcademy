using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ExchangeValues
{
    //Write an if statement that examines two integer variables and exchanges their values if the first one is greater than the second one.

    class ExchangeValues
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first integer: ");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter second integer: ");
            int secondNumber = int.Parse(Console.ReadLine());
            Console.WriteLine();

            int temp;

            if (firstNumber > secondNumber)
            {
                temp = firstNumber;
                firstNumber = secondNumber;
                secondNumber = temp;
                Console.WriteLine("The first number is greater than the second. Must to make exchange.");
                Console.WriteLine("Numbers after the exchange are:");
                Console.WriteLine();
            }

            Console.WriteLine("first integer: " + firstNumber);
            Console.WriteLine("second integer: " + secondNumber);
        }
    }
}
