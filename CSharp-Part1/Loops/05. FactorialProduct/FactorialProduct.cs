using System;
using System.Numerics;

namespace _05.FactorialProduct
{
    class FactorialProduct
    {
        //Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).

        static void Main(string[] args)
        {
            Console.WriteLine("Enter integer for N! : ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter integer for K! : ");
            int k = int.Parse(Console.ReadLine());

            int kn = k - n;

            BigInteger factN = 1;
            BigInteger factK = 1;
            BigInteger factKN = 1;

            if (1 < n && n < k)
            {
                for (int i = 1; i <= n; i++)
                {
                    factN *= i;
                }
                for (int i = 1; i <= k; i++)
                {
                    factK *= i;
                }
                for (int i = 1; i <= kn; i++)
                {
                    factKN *= i; 
                }

                Console.WriteLine("N!/K! = " + factN * factK / factKN);
            }
            else
            {
                Console.WriteLine("Invalid numbers!");
            }
        }
    }
}
