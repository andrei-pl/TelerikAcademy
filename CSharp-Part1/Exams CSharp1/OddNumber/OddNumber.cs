using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddNumber
{
    class OddNumber
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[] nNumbers = new long [n];
            long odd = 0;

            for (int i = 0; i < n; i++)
			{
                nNumbers[i] = long.Parse(Console.ReadLine());

                odd ^= nNumbers[i];
			}
                    Console.WriteLine(odd);
        }
    }
}
