using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _248
{
    class Program
    {
        static void Main(string[] args)
        {
            long a = int.Parse(Console.ReadLine());
            long b = int.Parse(Console.ReadLine());
            long c = int.Parse(Console.ReadLine());

            long firstResult = 0;

            if (b == 2)
            {
                firstResult = a % c;
            }
            else if (b == 4)
            {
                firstResult = a + c;
            }
            else if (b == 8)
            {
                firstResult = a * c;
            }

            long result = 0;
            if (firstResult % 4 == 0)
            {
                result = firstResult / 4;
            }
            else
            {
                result = firstResult % 4;
            }

            Console.WriteLine(result);
            Console.WriteLine(firstResult);
        }
    }
}
