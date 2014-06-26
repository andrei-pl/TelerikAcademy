using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteNumbers
{
    //Write a program that prints all the numbers from 1 to N.

    class WriteNumbers
    {
        static void Main(string[] args)
        {
            Console.Write("Enter to which number to print: ");
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
