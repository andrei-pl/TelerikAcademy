using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallDown
{
    class FallDown
    {
        static void Main(string[] args)
        {
            byte[] numbers = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                numbers[i] = byte.Parse(Console.ReadLine());
            }
            int row = 7;
            for (int col = 0; col < 8; col++)
            {
                int emptyIndex = -1;
                row = 7;
                while(row >= 0)
                {
                    byte mask = (byte)(1 << col);
                    if ((byte)(numbers[row] & mask) >> col == 1)
                    {
                        if (emptyIndex == -1)
                        {
                            if (row - 1 >= 0)
                            {
                                row--;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            numbers[emptyIndex] = (byte)(numbers[emptyIndex] | mask);
                            numbers[row] = (byte)(numbers[row] & ~mask);
                            row = emptyIndex - 1;
                            emptyIndex = -1;
                           
                        }
                    }
                    else
                    {
                        if (row > 0)
                        {
                            if (emptyIndex == -1)
                            {
                                emptyIndex = row;
                            }
                            row--;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }
    }
}
