﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnesAndZeros
{
    class OnesAndZeros
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string[,] numberStr = new string[5, 16];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 15; j >= 0; j--)
                {
                    int mask = 1 << j;
                    if ((number & mask) >> j == 0)
                    {
                        if (i == 0 || i == 4)
                        {
                            numberStr[i, 15 - j] = "###";
                        }
                        else
                        {
                            numberStr[i, 15 - j] = "#.#";
                        }
                    }
                    else
                    {
                        if (i == 4)
                        {
                            numberStr[i, 15 - j] = "###";
                        }
                        else if (i == 1)
                        {
                            numberStr[i, 15 - j] = "##.";
                        }
                        else
                        {
                            numberStr[i, 15 - j] = ".#.";
                        }
                    }
                }
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    Console.Write(numberStr[i, j]);
                    if (j != 15)
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
