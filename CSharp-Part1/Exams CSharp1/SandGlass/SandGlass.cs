using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandGlass
{
    class SandGlass
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i <= n / 2; i++)
            {
                string dots = new string('.', i);
                string stars = new string('*', n - 2 * i);

                Console.Write(dots);
                Console.Write(stars);
                Console.Write(dots);
                Console.WriteLine();

            }
            for (int i = n / 2 + 1; i < n; i++)
            {
                string dots = new string('.', (n -(2 *(i - n / 2) + 1) )/ 2);
                string stars = new string('*', 2 *(i - n / 2) + 1);

                Console.Write(dots);
                Console.Write(stars);
                Console.Write(dots);
                Console.WriteLine();
            }
        }
    }
}
