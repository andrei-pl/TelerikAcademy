using System;
using System.Numerics;

namespace TribonacciTriangle
{
    class Tribonacci
    {
        static void Main(string[] args)
        {
            BigInteger[] array = new BigInteger[3];
            array[0] = BigInteger.Parse(Console.ReadLine());
            array[1] = BigInteger.Parse(Console.ReadLine());
            array[2] = BigInteger.Parse(Console.ReadLine());
            BigInteger sum = array[0] + array[1] + array[2];
            BigInteger rows = BigInteger.Parse(Console.ReadLine());
            int count = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (count < 3)
                    {
                        if (j == 0)
                        {
                            Console.Write(array[count]);
                        }
                        else
                        {
                            Console.Write(" " + array[count]);
                        }
                        count++;
                    }
                    else
                    {
                        sum = array[0] + array[1] + array[2];
                        array[0] = array[1];
                        array[1] = array[2];
                        array[2] = sum;
                        if (j == 0)
                        {
                            Console.Write(sum);
                        }
                        else
                        {
                            Console.Write(" " + sum);
                        }
                        count++;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
