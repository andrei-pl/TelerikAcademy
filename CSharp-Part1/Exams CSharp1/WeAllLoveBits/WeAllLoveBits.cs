using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAllLoveBits
{
    class WeAllLoveBits
    {
        static void Main(string[] args)
        {
            //int n = int.Parse(Console.ReadLine());     //the original solution
            //int[] arrayN = new int[n];

            //for (int i = 0; i < arrayN.Length; i++)
            //{
            //    int number = int.Parse(Console.ReadLine());
            //    while (number > 0)
            //    {
            //        arrayN[i] <<= 1;
            //        if ((number & 1) == 1)
            //        {
            //            arrayN[i] |= 1;
            //        }
            //        number >>= 1;
            //    }
            //}
            //for (int i = 0; i < arrayN.Length; i++)
            //{
            //    Console.WriteLine(arrayN[i]);
            //}
            int n = int.Parse(Console.ReadLine());
            int[] p = new int[n];

            for (int i = 0; i < p.Length; i++)
            {
                p[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < p.Length; i++)
            {
                int position = 0;
                for (int j = Convert.ToString(p[i], 2).Length - 1; j >= Convert.ToString(p[i], 2).Length / 2; j--)
                {
                    if (position > j)
                    {
                        break;
                    }
                    int maskElder = (1 << j) & p[i];
                    int maskYounger = (1 << position) & p[i];
                    if (maskYounger >> position == 0 && maskElder >> j == 1)
                    {
                        maskYounger = 1 << j;
                        maskElder = 1 << position;
                        p[i] = (p[i] | maskElder) & ~maskYounger;
                    }
                    else if (maskYounger >> position == 1 && maskElder >> j == 0)
                    {
                        maskYounger = 1 << j;
                        maskElder = 1 << position;
                        p[i] = (p[i] | maskYounger) & ~maskElder;
                    }
                    position++;
                }
            }

            for (int i = 0; i < p.Length; i++)
            {
                Console.WriteLine(p[i]);
            }
        }
    }
}

