using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeValues
{
    class ExchangeValues
    {
        //Declare  two integer variables and assign them with 5 and 10 and after that exchange their values.

        static void Main(string[] args)
        {
            int a = 5;
            int b = 10;

            Console.WriteLine("a = " + a + "\nb = " + b);
            Console.WriteLine();

            a = a + b;
            b = a - b;
            a = a - b;

            Console.WriteLine("a = " + a + "\nb = " + b);
        }
    }
}
