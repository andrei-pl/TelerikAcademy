using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20.UniversalMethod
{
    class Program
    {
        //20. * By using delegates develop an universal static method to calculate the sum of infinite convergent series 
        //with given precision depending on a function of its term. By using proper functions for the term calculate 
        //with a 2-digit precision the sum of the infinite series:
        //1 + 1/2 + 1/4 + 1/8 + 1/16 + …
	    //1 + 1/2! + 1/3! + 1/4! + 1/5! + …
	    //1 + 1/2 - 1/4 + 1/8 - 1/16 + … 

        private static void Main()
        {
            double precision = 0.01;

            Func<int, double> first = x => Math.Pow(2, -x);
            Func<int, double> second = x => 1 / Factorial(x + 1);
            Func<int, double> third = x => x == 0 ? 1 : -Math.Pow(-2, -x);

            Console.WriteLine("1 + 1/2 + 1/4 + 1/8 + 1/16 + ... = {0:F2} ({0})", Result(first, precision));
            Console.WriteLine("1 + 1/2! + 1/3! + 1/4! + 1/5! + ... = {0:F2} ({0})", Result(second, precision));
            Console.WriteLine("1 + 1/2 - 1/4 + 1/8 - 1/16 + ... = {0:F2} ({0})", Result(third, precision));
        }


        private static double Result(Func<int, double> func, double precision)
        {
            double sum = 0;
            double tempSum = 0;
            int i = 0;

            do
            {
                tempSum = func(i);
                sum += tempSum;
                i++;
            } while (Math.Abs(tempSum) > precision);

            return sum;
        }

        private static double Factorial(int num)
        {
            double result = 1;
            while (num > 1)
            {
                result *= num;
                num--;
            }

            return result;
        }
    }
}
