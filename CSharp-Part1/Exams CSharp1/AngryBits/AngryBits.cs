using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngryBits
{
    class AngryBits
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[8, 16];

            for (int i = 0; i < 8; i++)
            {
                int number;
                do
                {
                    number = int.Parse(Console.ReadLine());
                } while (i < 0 || i > 65535);

                for (int j = 0; j < 16; j++)
                {
                    int mask = (number >> j) & 1;
                    matrix[i, j] = mask;
                }
            }

            bool pig = false;
            int counterMoves = 0;
            int counterPigs = 0;
            int score = 0;
            bool up = true;

            for (int j = 8; j < 16; j++)
            {
                int i = 0;
                counterMoves = 0;
                counterPigs = 0;
                up = true;

                while (i < 8)
                {
                    if (matrix[i, j] == 1)
                    {
                        matrix[i, j] = 0;

                        for (int n = j - 1; n >= 0; n--)
                        {
                            counterMoves++;
                            if (i == 0)
                            {
                                up = false;
                            }
                            if (up)
                            {
                                i--;
                            }
                            else
                            {
                                i++;
                            }
                            if (i == 8)
                            {
                                break;
                            }
                            if (matrix[i, n] == 1)
                            {
                                pig = true;
                                matrix[i, n] = 0;
                                counterPigs++;
                                if (matrix[i, n + 1] == 1)
                                {
                                    matrix[i, n + 1] = 0;
                                    counterPigs++;
                                }
                                if (i != 0)
                                {
                                    if (matrix[i - 1, n] == 1)
                                    {
                                        matrix[i - 1, n] = 0;
                                        counterPigs++;
                                    }
                                    if (matrix[i - 1, n + 1] == 1)
                                    {
                                        matrix[i - 1, n + 1] = 0;
                                        counterPigs++;
                                    }
                                }
                                if (i < 7)
                                {
                                    if (matrix[i + 1, n] == 1)
                                    {
                                        matrix[i + 1, n] = 0;
                                        counterPigs++;
                                    }
                                    if (matrix[i + 1, n + 1] == 1)
                                    {
                                        matrix[i + 1, n + 1] = 0;
                                        counterPigs++;
                                    }
                                }
                                if (n != 0)
                                {
                                    if (i != 0)
                                    {
                                        if (matrix[i - 1, n - 1] == 1)
                                        {
                                            matrix[i - 1, n - 1] = 0;
                                            counterPigs++;
                                        }
                                    }
                                    if (matrix[i, n - 1] == 1)
                                    {
                                        matrix[i, n - 1] = 0;
                                        counterPigs++;
                                    }
                                    if (i < 7)
                                    {
                                        if (matrix[i + 1, n - 1] == 1)
                                        {
                                            matrix[i + 1, n - 1] = 0;
                                            counterPigs++;
                                        }
                                    }
                                }
                            }

                            if (pig == true)
                            {
                                break;
                            }
                        }
                    }
                    if (pig == true)
                    {
                        score += counterMoves * counterPigs;
                        pig = false;
                        i = 8;
                    }
                    else
                    {
                       i++;
                    }
                }
            }
            string isWin = "Yes";

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        isWin = "No";
                    }
                }
                
            }
            Console.WriteLine(score + " " + isWin);
        }
    }
}
