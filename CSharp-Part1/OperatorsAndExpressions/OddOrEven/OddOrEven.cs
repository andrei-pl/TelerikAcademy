using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddOrEven
{
    class OddOrEven
    {
        //Write an expression that checks if given integer is odd or even.

        static void Main(string[] args)
        {
            Console.Write("Enter one integer number: ");
            int number = Int32.Parse(Console.ReadLine());

            string oddOrEven = (number % 2 == 0)?number + " is even.":number + " is odd.";
            Console.WriteLine(oddOrEven);
        }
    }
}
