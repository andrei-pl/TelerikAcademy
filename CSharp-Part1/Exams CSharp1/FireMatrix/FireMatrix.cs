using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireMatrix
{
    class FireMatrix
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int height = n + (n / 4) + 1;

            int a = n / 2 - 1;
            int b = n / 2;
            int c = 0;
            int d = n / 2;
            int jValueDec = n - 1;
            int jValueInc = 0;
            int iValue = 0;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == n / 2 && j == 0)
                    {
                        a = 0;
                        b = n - 1;
                    }
                    if (i > n / 2 + n / 4 + 1 && j == 0)
                    {
                        jValueDec--;
                        c = ++jValueInc;
                        d = n / 2;
                    }
                    if (i < n / 2 && j == a)
                    {
                        Console.Write("#");
                        a--;
                    }
                    else if (i < n / 2 && j == b && iValue == i)
                    {
                        Console.Write("#");
                        b++;
                        iValue++;
                    }
                    else if (i >= n / 2 && i < n / 2 + n / 4 && j == a && iValue == i)
                    {
                        Console.Write("#");
                        a++;
                        iValue++;
                    }
                    else if (i >= n / 2 && i < n / 2 + n / 4 && j == b)
                    {
                        Console.Write("#");
                        b--;
                    }
                    else if (i == n / 2 + n / 4)
                    {
                        Console.Write("-");
                    }
                    else if (i > n / 2 + n / 4 && j == c && j < n / 2 && j >= jValueInc)
                    {
                        Console.Write("\\");
                        c++;
                    }
                    else if (i > n / 2 + n / 4 && j == d && j <= jValueDec)
                    {
                        Console.Write("/");
                        d++;
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
