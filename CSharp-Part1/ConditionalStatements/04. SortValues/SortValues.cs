using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SortValues
{
    //Sort 3 real values in descending order using nested if statements.

    class SortValues
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first number: ");
            double firstNumber = double.Parse(Console.ReadLine());
            Console.Write("Enter second integer: ");
            double secondNumber = double.Parse(Console.ReadLine());
            Console.Write("Enter third integer: ");
            double thirdNumber = double.Parse(Console.ReadLine());

            Console.WriteLine("The numbers you enter are: " + firstNumber + " " + secondNumber + " " + thirdNumber);

            double temp = firstNumber;

            if (firstNumber < secondNumber)
            {
                temp = firstNumber;
                firstNumber = secondNumber;
                secondNumber = temp;
                if (secondNumber < thirdNumber)  //it's not necessary to have it, but only for the condition
                {
                    temp = secondNumber;
                    secondNumber = thirdNumber;
                    thirdNumber = temp;
                }
            }
            else if (secondNumber < thirdNumber)  //if the above nested "if" was not, than this must be only "if" without "else"
            {                                                       //And that way, the source code will be much better
                temp = secondNumber;
                secondNumber = thirdNumber;
                thirdNumber = temp;
            }
            
            if (firstNumber < secondNumber)
            {
                temp = firstNumber;
                firstNumber = secondNumber;
                secondNumber = temp;
            }

            Console.WriteLine("Numbers in descending order: " + firstNumber + " " + secondNumber + " " + thirdNumber);
        }
    }
}
