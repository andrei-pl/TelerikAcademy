using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyDwarf
{
    class GreedyDwarf
    {
        static void Main(string[] args)
        {
            int[] valley = Console.ReadLine().Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int m = int.Parse(Console.ReadLine());
            int[][] patterns = new int[m][];
            int maxAmount = int.MinValue;
            
            for (int i = 0; i < m; i++)
            {
                patterns[i] = Console.ReadLine().Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                bool[] isUsed = new bool[valley.Length];
                int step = 0;
                int tempSum = 0;
                int index = 0;

                while (step < isUsed.Length && step >= 0 && isUsed[step] == false)
                {
                    tempSum += valley[step];
                    isUsed[step] = true;
                    step += patterns[i][index];
                    if (index + 1 < patterns[i].Length)
                    {
                        index++;
                    }
                    else
                    {
                        index = 0;
                    }
                }
                if (maxAmount < tempSum)
                {
                    maxAmount = tempSum;
                }
            }
            Console.WriteLine(maxAmount);
        }
    }
}
