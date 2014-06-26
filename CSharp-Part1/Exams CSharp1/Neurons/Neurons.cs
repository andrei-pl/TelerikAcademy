using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neurons
{
    class Neurons
    {
        static void Main(string[] args)
        {
            uint[] numbers = new uint[32];
            bool isNotEnd = true;
            int counter = 0;

            do
            {
                if (isNotEnd = uint.TryParse(Console.ReadLine(), out numbers[counter]))
                {
                    counter++;
                }
            } while (isNotEnd == true);

            for (int i = 0; i < counter; i++)
            {
                bool isInside = false;
                bool isOutside = false;

                for (int j = 0; j < 32; j++)
                {
                    int mask = 1 << j;
                    if (((numbers[i] & mask) >> j) == 1)
                    {
                        numbers[i] = (uint)(numbers[i] ^ mask);

                        if (!isOutside)
                        {
                            isInside = true;
                        }
                        else
                        {
                            isInside = false;
                        }
                    }
                    else
                    {
                        if (isInside)
                        {
                            numbers[i] = (uint)(numbers[i] ^ mask);
                            isOutside = true;
                        }
                    }
                }
                if (isInside == true)
                {
                    numbers[i] = 0;
                }
                Console.WriteLine(numbers[i]);
            }
        }
    }
}
