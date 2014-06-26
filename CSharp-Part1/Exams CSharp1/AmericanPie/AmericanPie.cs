using System;
using System.Numerics;

namespace AmericanPie
{
    class AmericanPie
    {
        static void Main(string[] args)
        {
            decimal A = decimal.Parse(Console.ReadLine());
            decimal B = decimal.Parse(Console.ReadLine());
            decimal C = decimal.Parse(Console.ReadLine());
            decimal D = decimal.Parse(Console.ReadLine());

            if (A / B + C / D >= 1)
            {
                Console.WriteLine((int)(A / B + C / D));
            }
            else
            {
                Console.WriteLine("{0:F20}", A / B + C / D);
            }

            BigInteger nominator = 0;
            BigInteger deNominator = 0;
            if (B == D)
            {
                deNominator = (BigInteger)B;
                nominator = (BigInteger)(A + C);
            }
            else
            {
                nominator = (BigInteger)(A * D + B * C);
                deNominator = (BigInteger)(B * D);
            }
            Console.WriteLine(nominator + "/" + deNominator);
        }
    }
}
