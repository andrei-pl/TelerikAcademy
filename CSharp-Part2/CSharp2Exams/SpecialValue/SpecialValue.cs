using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialValue
{
    class SpecialValue
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] lines = new int[n][];

            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }
            Console.WriteLine(GetMaxValue(lines));
        }

        static int GetMaxValue(int[][] lines)
        {
            bool[][] isPassed = new bool[lines.GetLength(0)][];
            int result = int.MinValue;

            for (int i = 0; i < lines[0].Length; i++)
            {
                int dx = 0;
                int dy = i;
                int steps = 0;

                for (int j = 0; j < lines.GetLength(0); j++)
                {
                    isPassed[j] = new bool[lines[j].Length];
                }

                while (true)
                {
                    steps++;

                    if (lines[dx][dy] < 0 || isPassed[dx][dy])
                    {
                        if (result < steps - lines[dx][dy])
                        {
                            result = steps - lines[dx][dy];
                        }
                        break;
                    }

                    isPassed[dx][dy] = true;

                    dy = lines[dx][dy];
                    dx++;
                    if (dx == lines.GetLength(0))
                    {
                        dx = 0;
                    }
                }
            }
            return result;
        }
    }
}
