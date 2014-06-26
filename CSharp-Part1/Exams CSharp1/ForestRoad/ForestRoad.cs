using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestRoad
{
    class ForestRoad
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int a = 0;
            int iCon = 0;

            for (int i = 0; i < 2 * n - 1; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i < n - 1)
                    {
                        if (j == a && i == iCon)
                        {
                            Console.Write("*");
                            a++;
                            iCon++;
                        }
                        else
                        {
                            Console.Write(".");
                        }
                    }
                    else
                    {
                        if (j == a)
                        {
                            Console.Write("*");
                            a--;
                        }
                        else
                        {
                            Console.Write(".");
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
