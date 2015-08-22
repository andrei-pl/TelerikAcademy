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
            int n = int.Parse(Console.ReadLine());

            int width = (n * 2) + 1;
            int height = 6 + ((n - 3) / 2) * 3;

            Console.WriteLine(new string('.', n) + "*" + new string('.', n));

            int top = (height * 2 / 3) - 2;
            int bottom = (height / 3) - 1;
            int outerDots = n - 1;
            int innerDots = 0;

            for (int i = 0; i < top; i++)
            {
                Console.WriteLine(new string('.', outerDots) + "*" + new string('.', innerDots) + "*" + new string('.', innerDots) + "*" + new string('.', outerDots));
                outerDots--;
                innerDots++;
            }

            Console.WriteLine(new string('*', width));

            for (int i = 0; i < bottom; i++)
            {
                outerDots++;
                innerDots--;
                Console.WriteLine(new string('.', outerDots) + "*" + new string('.', innerDots) + "*" + new string('.', innerDots) + "*" + new string('.', outerDots));
            }

            Console.WriteLine(new string('.', (width - n) / 2) + new string('*', n) + new string('.', (width - n) / 2));
        }
    }
}
