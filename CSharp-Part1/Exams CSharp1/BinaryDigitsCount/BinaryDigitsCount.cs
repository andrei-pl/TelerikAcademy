using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryDigitsCount
{
    class BinaryDigitsCount
    {
        static void Main(string[] args)
        {
            string bit = Console.ReadLine();
            int numbers = int.Parse(Console.ReadLine());
            long[] arrayNumbers = new long[numbers];
            int[] arrayBits = new int[numbers];

            for (int i = 0; i < numbers; i++)
            {
                arrayNumbers[i] = long.Parse(Console.ReadLine());
                string number = Convert.ToString(arrayNumbers[i], 2);
                for (int j = 0; j < number.Length; j++)
                {
                    if (number[j].ToString() == bit)
                    {
                        arrayBits[i]++;
                    }
                }
            }
            for (int i = 0; i < arrayBits.Length; i++)
            {
                Console.WriteLine(arrayBits[i]);
            }

        }
    }
}
