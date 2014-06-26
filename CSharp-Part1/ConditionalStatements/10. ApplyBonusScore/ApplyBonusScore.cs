using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.ApplyBonusScore
{
    class ApplyBonusScore
    {
        //Write a program that applies bonus scores to given scores in the range [1..9]. The program reads a digit as an input.
        //If the digit is between 1 and 3, the program multiplies it by 10; if it is between 4 and 6, multiplies it by 100; 
        //if it is between 7 and 9, multiplies it by 1000. If it is zero or if the value is not a digit, the program must report an error.
		//Use a switch statement and at the end print the calculated new value in the console.

        static void Main(string[] args)
        {
            Console.Write("Enter some digit: ");
            string someValue = Console.ReadLine();
            int digit;
            bool isDigit = int.TryParse(someValue, out digit);

            if (isDigit)
            {
                switch (digit)
                {
                    case 0:
                        Console.WriteLine("Sorry, but no bonus scores for 0.");
                        break;
                    case 1:
                    case 2:
                    case 3:
                        digit = digit * 10;
                        break;
                    case 4:
                    case 5:
                    case 6:
                        digit = digit * 100;
                        break;
                    case 7:
                    case 8:
                    case 9:
                        digit = digit * 1000;
                        break;
                    default:
                        Console.WriteLine("This is not a digit.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("This is not even an integer.");
            }
            Console.WriteLine("You have " + digit + " with your bonus score.");
        }
    }
}
