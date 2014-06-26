
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspichaniaBoats
{
    class KaspichaniaBoats
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int weight = 2 * N + 1;
            int height = 6 + ((N - 3) / 2) * 3;
            int countEndDots = 0;
            int countMiddleDots = 0;

            for (int i = 0; i < height * 2 / 3 - 1; i++)
            {
                if (i == 0)
                {
                    string dots = new string('.', weight / 2);
                    Console.Write(dots + "*" + dots);
                    Console.WriteLine();
                }
                else
                {
                    string dotsEnd = new string('.', weight / 2 - i);
                    string dotsMiddle = new string('.', i - 1);
                    countEndDots = weight / 2 - i;
                    countMiddleDots = i - 1;

                    Console.Write(dotsEnd + "*" + dotsMiddle + '*' + dotsMiddle + '*' + dotsEnd);
                    Console.WriteLine();
                }
            }
            Console.WriteLine(new string('*', weight));
            for (int i = height *2 / 3; i < height; i++)
			{
                string dotsEnd = new string('.', countEndDots);
                string dotsMiddle = new string('.', countMiddleDots);

                if (i == height - 1)
                {
                    Console.Write(dotsEnd);
                    Console.Write(new string('*', N));
                    Console.WriteLine(dotsEnd);
                }
                else
                {
                    countEndDots++;
                    countMiddleDots--;

                    Console.Write(dotsEnd + "*" + dotsMiddle + '*' + dotsMiddle + '*' + dotsEnd);
                    Console.WriteLine();
                }
			}
        }
    }
}
