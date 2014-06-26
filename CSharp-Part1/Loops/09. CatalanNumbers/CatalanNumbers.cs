using System;
using System.Numerics;

namespace _09CatalanNumbers
{
    //In the combinatorial mathematics, the Catalan numbers are calculated by the following formula: Cn = (2n)!/((n + 1)! * n!)  for n >= 0
    //Write a program to calculate the Nth Catalan number by given N.

    class CatalanNumbers
    {
        static void Main(string[] args)
        {
            Console.Write("Enter some integer for \"n\": ");
            int n = int.Parse(Console.ReadLine());

            int n2 = 2 * n;
            int nAdd1 = n + 1;
            BigInteger catalan = 0;

            BigInteger factN = 1;
            BigInteger fact2N = 1;
            BigInteger factNAdd1 = 1;

            if (n >= 0)
            {
                if (n == 0)
                {
                    catalan = 1;
                }
                else
                {
                    for (int i = 1; i <= n; i++)
                    {
                        factN *= i;
                    }
                    for (int i = 1; i <= n2; i++)
                    {
                        fact2N *= i;
                    }
                    for (int i = 1; i <= nAdd1; i++)
                    {
                        factNAdd1 *= i;
                    }
                    catalan = fact2N / (factNAdd1 * factN); 
                }
            }
            else
            {
                Console.WriteLine("Invalid number!");
            }
            Console.WriteLine("Cn = " + catalan);
        }
    }
}
