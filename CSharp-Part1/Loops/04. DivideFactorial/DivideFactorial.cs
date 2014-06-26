using System;
using System.Numerics;

namespace _04.DivideFactorial
{
    class DivideFactorial
    {
        //Write a program that calculates N!/K! for given N and K (1<K<N).

        static void Main(string[] args)
        {
            Console.WriteLine("Enter integer for N! : ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter integer for K! : ");
            int k = int.Parse(Console.ReadLine());

            BigInteger factN = 1;
            BigInteger factK = 1;

            if (k > 1 && n > k)
            {
                for (int i = 1; i <= n; i++)
                {
                    factN *= i;
                }
                for (int i = 1; i <= k; i++)
                {
                    factK *= i;
                }

                Console.WriteLine("N!/K! = " + factN / factK);
            }
            else
            {
                Console.WriteLine("Invalid numbers!");
            }
        }
    }
}
