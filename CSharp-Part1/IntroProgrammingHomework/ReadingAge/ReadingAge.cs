using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingAge
{
    class ReadingAge
    {
        static void Main(string[] args)
        {
            int currentAge;

            do
            {
                Console.Write("Type your age here: ");
                currentAge = Int32.Parse(Console.ReadLine());
            } while (currentAge < 0 || currentAge > 120);

            Console.WriteLine("You will be " + (currentAge + 10) + " in 10 years!");
        }
    }
}
