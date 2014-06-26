using System;
using System.Numerics;

namespace QuadronacciRectangle
{
    class QuadronacciRectangle
    {
        static void Main(string[] args)
        {
            BigInteger[] q = new BigInteger[4];
            q[0] = BigInteger.Parse(Console.ReadLine());
            q[1] = BigInteger.Parse(Console.ReadLine());
            q[2] = BigInteger.Parse(Console.ReadLine());
            q[3] = BigInteger.Parse(Console.ReadLine());
            int r = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            BigInteger qSum = q[0] + q[1] + q[2] + q[3];
            int count = 0;

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (count < 4)
                    {
                        if (j == 0)
                        {
                            Console.Write(q[count]);
                        }
                        else
                        {
                            Console.Write(" " + q[count]);
                        }
                        count++;
                    }
                    else
                    {
                        qSum = q[0] + q[1] + q[2] + q[3];
                        q[0] = q[1];
                        q[1] = q[2];
                        q[2] = q[3];
                        q[3] = qSum;
                        if (j == 0)
                        {
                            Console.Write(qSum);
                        }
                        else
                        {
                            Console.Write(" " + qSum);
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
