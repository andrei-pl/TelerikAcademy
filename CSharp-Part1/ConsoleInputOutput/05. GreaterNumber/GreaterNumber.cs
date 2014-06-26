using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.GreaterNumber
{
   // Write a program that gets two numbers from the console and prints the greater of them. Don’t use if statements.

    class GreaterNumber
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first number: ");
            int firstNumber = Int32.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            int secondNumber = Int32.Parse(Console.ReadLine());

            int max = (firstNumber > secondNumber) ? firstNumber : secondNumber;
            
            Console.WriteLine("The greater number is: " + max);
        }
    }
}
