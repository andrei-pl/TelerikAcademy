using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheets
{
    class Sheets
    {
        static void Main(string[] args)
        {
            int nSheets = int.Parse(Console.ReadLine());

            int[] aSheet = {1024, 512, 256, 128, 64, 32, 16, 8, 4, 2, 1};
            int count = nSheets;

            for (int i = 0; i < 11; i++)
            {
                if (count - aSheet[i] >= 0)
                {
                    count -= aSheet[i];
                }
                else
                {
                    Console.WriteLine("A" + i);
                }
            }
        }
    }
}
