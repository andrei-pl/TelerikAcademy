using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintNumbers_1_101_1001
{
    class PrintNumbers
    {
        static void Main(string[] args)
        {
            int number = 1;

            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine(number.ToString());
                }
                else
                {
                    Console.WriteLine(Math.Pow(10, i).ToString() + "1");
                }
            }
        }
    }
}
