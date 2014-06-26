using System;
using System.Numerics;

namespace DrunkenNumbers
{
    class DrunkenNumbers
    {
        static void Main(string[] args)
        {
            int round = int.Parse(Console.ReadLine());
            
            int m = 0;
            int v = 0;

            for (int i = 0; i < round; i++)
            {
                BigInteger number = BigInteger.Parse(Console.ReadLine());
                if (number < 0)
                {
                    number *= -1;
                }
                string numString = number.ToString();

                if (numString.Length % 2 == 0)
                {
                    for (int j = 0; j < numString.Length / 2; j++)
                    {
                        int tempJ = int.Parse(numString[j].ToString());
                        m += tempJ;
                    }
                    for (int j = numString.Length / 2; j < numString.Length; j++)
                    {
                        int tempJ = int.Parse(numString[j].ToString());
                        v += tempJ;
                    }
                }
                else
                {
                    for (int j = 0; j <= numString.Length / 2; j++)
                    {
                        int tempJ = int.Parse(numString[j].ToString());
                        m += tempJ;
                    }
                    for (int j = numString.Length / 2; j < numString.Length; j++)
                    {
                        int tempJ = int.Parse(numString[j].ToString());
                        v += tempJ;
                    }
                }
            }
            if (v > m) { Console.WriteLine("V " + (v - m)); }
            else if (m > v) { Console.WriteLine("M " + (m - v)); }
            else { Console.WriteLine("No " + (v + m)); }

        }
    }
}
