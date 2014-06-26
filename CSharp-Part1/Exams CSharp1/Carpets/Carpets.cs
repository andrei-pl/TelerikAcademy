using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpets
{
    class Carpets
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string left = "/";
            string right = "\\";
            string space = " ";
            int rombStart = n / 2 - 1;
            int rombEnd = n / 2;

            for (int i = 0; i < n; i++)
            {
                if (i == n / 2)
                {
                    string temp = left;
                    left = right;
                    right = temp;
                    rombStart++;
                    rombEnd--;
                }

                for (int col = 0; col < rombStart; col++)
                {
                    Console.Write(".");
                }
                int targets = n - (2 * rombStart);
                for (int col = 0; col < targets; col++)
                {
                    if (col < targets / 2)
                    {
                        Console.Write((col % 2) == 0 ? left : space);
                    }
                    else
                    {
                        Console.Write((col % 2) != 0 ? right : space);
                    }
                }
                for (int col = 0; col < rombStart; col++)
                {
                    Console.Write(".");
                }
                if (i < n / 2)
                {
                    rombStart--;
                    rombEnd++;
                }
                else
                {
                    rombStart++;
                    rombEnd--;
                }
                Console.WriteLine();
            }
        }
    }
}
