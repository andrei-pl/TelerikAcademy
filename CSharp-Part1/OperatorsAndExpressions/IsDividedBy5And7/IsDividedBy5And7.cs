using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsDividedBy5And7
{
    class IsDividedBy5And7
    {
        //Write a boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time.

        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int number = Int32.Parse(Console.ReadLine());
           
            bool isDivided = ((number % 35) == 0) ? true : false;

            if (isDivided)
            {
                Console.WriteLine("{0} can be divided by 5 and 7 at the same time.", number);
            }
            else
            {
                Console.WriteLine("{0} can't be divided by 5 and 7 at the same time.", number);
            }
        }
    }
}
