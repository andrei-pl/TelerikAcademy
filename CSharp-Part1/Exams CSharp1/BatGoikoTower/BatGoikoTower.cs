using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatGoikoTower
{
    class BatGoikoTower
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int a = n - 1;
            int b = n;
            int counter = 0;
            int crossbeamsCounter = 1;
            int positionCrossbeams = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n * 2; j++)
                {
                    if (a == j)                //all ather rows
                    {
                        Console.Write("/");
                        a--;
                    }
                    else if (b == j && counter == i)
                    {
                        Console.Write("\\");
                        b++;
                        counter++;
                    }
                    else if (positionCrossbeams == i && j > a && j < b) 
                    {
                        Console.Write("-");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                if (positionCrossbeams == i)
                {
                    positionCrossbeams += crossbeamsCounter++;
                }
                Console.WriteLine();
            }
        }
    }
}
