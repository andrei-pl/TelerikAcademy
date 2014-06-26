using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsThirdDigit7RightToLeft
{
    class IsThirdDigit7RightToLeft
    {
        static void Main(string[] args)
        {
            //Write an expression that checks for given integer if its third digit (right-to-left) is 7. E. g. 1732  true.

            Console.WriteLine("Enter a number that contains minimum 3 digits: ");
            int number = Int32.Parse(Console.ReadLine());

            int digit = 0;

            if (number.ToString().Length >= 3)
            {
                if (number.ToString()[number.ToString().Length - 3] == '7')
                {
                    digit = 7;
                }

                bool isThirdDigit7RightToleft = (digit == 7) ? true : false;

                if (isThirdDigit7RightToleft)
                {
                    Console.WriteLine("Third digit (right to left) of the given integer is 7.");
                }
                else
                {
                    Console.WriteLine("Third digit (right to left) of the given integer is diferent from 7.");
                }
            }
            else
            {
                Console.WriteLine("This number is less than 100");
            }
        }
    }
}
