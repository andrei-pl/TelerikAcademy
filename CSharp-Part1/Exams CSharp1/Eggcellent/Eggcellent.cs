using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eggcellent
{
    class Eggcellent
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int outSideDots = n + 1;
            int inSideDots = n - 3;
            int count = 0;
            for (int i = 0; i < n - 1; i++)
            {

                Console.Write(new string('.', outSideDots));
                if (i == 0)
                {
                    Console.Write(new string('*', n - 1));
                }
                else
                {
                    Console.Write('*');
                    Console.Write(new string('.', inSideDots));
                    Console.Write('*');
                }
                Console.WriteLine(new string('.', outSideDots));
                if (outSideDots > 1)
                {
                    outSideDots -= 2;
                    inSideDots += 4;
                    count++;
                }
            }
            for (int i = 0; i < 2; i++)
            {
                Console.Write(".*");
                for (int j = 0; j < 3 * n - 3; j++)
                {
                    if (i == 0)
                    {
                        if (j % 2 != 0)
                        {
                            Console.Write(".");
                        }
                        else
                        {
                            Console.Write("@");
                        }
                    }
                    else
                    {
                        if (j % 2 != 0)
                        {
                            Console.Write("@");
                        }
                        else
                        {
                            Console.Write(".");
                        }
                    }
                }
                Console.WriteLine("*.");
            }
            for (int i = 0; i < n - 1; i++)
            {
                if (count > 1)
                {
                    count--;
                }
                else
                {
                    inSideDots -= 4;
                    outSideDots += 2;
                }
                Console.Write(new string('.', outSideDots));
                if (i == n - 2)
                {
                    Console.Write(new string('*', n - 1));
                }
                else
                {
                    Console.Write('*');
                    Console.Write(new string('.', inSideDots));
                    Console.Write('*');
                }
                Console.WriteLine(new string('.', outSideDots));

            }
        }
    }
}
