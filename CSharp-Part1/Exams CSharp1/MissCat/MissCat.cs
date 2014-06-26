using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissCat
{
    class MissCat
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arrayN = new int[n];
            int winner = 0;
            int winTimes = 0;

            int[] num = new int[10];

            for (int i = 0; i < n; i++)
            {
                arrayN[i] = int.Parse(Console.ReadLine());
                switch (arrayN[i])
                {
                    case 1: 
                    case 2: 
                    case 3: 
                    case 4: 
                    case 5: 
                    case 6: 
                    case 7: 
                    case 8: 
                    case 9:
                    case 10: num[arrayN[i] - 1]++; break;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                if (winTimes < num[i])
                {
                    winTimes = num[i];
                    winner = i + 1;
                }
            }
            Console.WriteLine(winner);
        }
    }
}
