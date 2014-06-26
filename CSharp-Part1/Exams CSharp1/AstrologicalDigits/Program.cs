using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace AstrologicalDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            string someNumber = Console.ReadLine();

            someNumber = someNumber.Replace(",", "");
            someNumber = someNumber.Replace(".", "");
            someNumber = someNumber.Replace("-", "");
          
            BigInteger astroDigit = BigInteger.Parse(someNumber);

            while(astroDigit > 9)
            {
                BigInteger astroNumber = 0;

                for (int i = 0; i < someNumber.Length; i++)
                {
                    astroNumber += astroDigit % 10;
                    astroDigit /= 10;
                }
                astroDigit = astroNumber;
                someNumber = astroDigit.ToString();
            }
            Console.WriteLine(astroDigit);
        }
    }
}
