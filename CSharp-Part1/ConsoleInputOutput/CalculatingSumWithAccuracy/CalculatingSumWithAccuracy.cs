using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatingSumWithAccuracy
{
    class CalculatingSumWithAccuracy
    {
        //Write a program to calculate the sum (with accuracy of 0.001): 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...

        static void Main(string[] args)
        {
            double sum = 1;

            for (int i = 2; i < 100; i++)
            {
                if (i % 2 == 0)
                {
                    sum += 1 / (double)i;
                }
                else
                {
                    sum -= 1 / (double)i;
                }
            }
            Console.WriteLine("The sum for the numbers 1 + 1/2 -1/3 + 1/4 -1/5 +....-1/99 = {0:F3}", sum);
        }
    }
}
