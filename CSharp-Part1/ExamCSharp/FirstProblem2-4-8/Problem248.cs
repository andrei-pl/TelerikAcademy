using System;
using System.Numerics;

namespace FirstProblem2_4_8
{
    class Problem248
    {
        static void Main(string[] args)
        {
            BigInteger A = BigInteger.Parse(Console.ReadLine());
            BigInteger B = BigInteger.Parse(Console.ReadLine());
            BigInteger C = BigInteger.Parse(Console.ReadLine());

            BigInteger remainder = 0;

            if (B == 2)
            {
                remainder = A % C;
            }
            else if (B == 4)
            {
                remainder = A + C;
            }
            else if(B == 8)
            {
                remainder = A * C;
            }
            BigInteger result = 0;

            if (remainder % 4 == 0)
            {
                result = remainder / 4;
            }
            else
            {
                result = remainder % 4;
            }
            Console.WriteLine(result);
            Console.WriteLine(remainder);
        }
    }
}
