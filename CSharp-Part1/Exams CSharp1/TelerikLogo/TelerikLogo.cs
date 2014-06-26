using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikLogo
{
    class TelerikLogo
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int width = ((n / 2) + n) * 2 - 1;
            int a = 0;
            int b = width - (n / 2) * 2 - 1;
            int iInc = 0;
            int m = n / 2;
            int p = -1;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    if (m == j)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                for (int j = 0; j < width - (n / 2) * 2; j++)
                {
                    if ((j == a || j == b) && i == iInc)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                for (int j = 0; j < n / 2; j++)
                {
                    if (p < n - 2 && p >= 0 && iInc == i && p == j)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                if (iInc >= n * 2 - 2)
                {
                    a--;
                    b++;
                }
                else
                {
                    a++;
                    b--;
                }
                iInc++;
                m--;
                p++;
                Console.WriteLine();
            }
        }
    }
}
