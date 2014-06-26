using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoroTheRabbit
{
    class JoroTheRabbit
    {
        static void Main(string[] args)
        {
            int[] terrain = Console.ReadLine().Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int maxSteps = 0;

            for (int position = 0; position < terrain.Length; position++)
            {
                for (int step = 1; step < terrain.Length; step++)
                {
                    int index = position;
                    int completeSteps = 1;
                    int next = position + step; //(position + step) % terrain.Length
                    if (next >= terrain.Length)
                    {
                        next -= terrain.Length;
                    }
                    
                    while (terrain[index] < terrain[next])
                    {
                        completeSteps++;
                        index = next;
                        next = (index + step) % terrain.Length;
                    }
                    if (maxSteps < completeSteps) maxSteps = completeSteps;
                }
            }
            Console.WriteLine(maxSteps);
        }
    }
}
