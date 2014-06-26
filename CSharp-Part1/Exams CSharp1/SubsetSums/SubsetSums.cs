using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetSums
{
    class SubsetSums
    {
        static void Main(string[] args)
        {
            long s = long.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            long[] numbers = new long[n];
            int counter = 0;
            for (int i = 0; i < n; i++)
            {
                numbers[i] = long.Parse(Console.ReadLine());
            }
            for (int i = 1; i <= Math.Pow(2, n) - 1; i++)    
            {
                long sum = 0;
                for (int j = 0; j < n; j++)
                {
                    sum += (long)(((i >> j) & 1) * numbers[j]);
                }
                if (sum == s)
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
