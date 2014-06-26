using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenlandNumbers
{
    class SevenlandNumbers
    {
        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());
            char[] arrayK = k.ToString().ToCharArray();
            int n = k.ToString().Length - 1;
            int k10 = 0;

            for (int i = 0; i < arrayK.Length; i++) //10 to 7 number system
            {
                int num = int.Parse(arrayK[i].ToString());
                k10 += (int)(num * Math.Pow(7, n));
                n--;
            }
            k10++;
            int num7 = k10;
            arrayK = new char[k.ToString().Length + 1];
            n = k.ToString().Length;
            int i7 = arrayK.Length -1;

            while (num7 != 0)  //7 to 10 number system
            {
                arrayK[i7] = char.Parse((num7 % 7).ToString());
                num7 = num7 / 7;
                i7--;

            }
            for (int j = 0; j < arrayK.Length; j++)
            {
                if (arrayK[j] == '\0')
                {
                    arrayK[j] = '0';
                }
            }
            k = int.Parse(new string(arrayK));
            Console.WriteLine(k);
        }
    }
}
