using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.DependingOnChoice
{
    class DependingOnChoice
    {
        //Write a program that, depending on the user's choice inputs int, double or string variable. 
        //If the variable is integer or double, increases it with 1. If the variable is string, appends "*" at its end. 
        //The program must show the value of that variable as a console output. Use switch statement.

        static void Main(string[] args)
        {
            Console.WriteLine("Enter some integer, real number or string:");
            string someText = Console.ReadLine();
            int intNumber;
            double doubleNumber;

            bool isInt = int.TryParse(someText, out intNumber);
            bool isDouble = double.TryParse(someText, out doubleNumber);

            int switchCase = 0;

            if (isInt == true)
            {
                switchCase = 1;
            }
            else if (isDouble == true)
            {
                switchCase = 2;
            }
            else
            {
                switchCase = 3;
            }

            switch (switchCase)
            {
                case 1:
                    intNumber = intNumber + 1;
                    Console.WriteLine("Increased integer number: " + intNumber);
                    break;
                case 2:
                    doubleNumber = doubleNumber + 1;
                    Console.WriteLine("Increased double number: " + doubleNumber);
                    break;
                case 3:
                    someText = someText + "*";
                    Console.WriteLine("The string is: " + someText);
                    break;
            }
        }
    }
}
