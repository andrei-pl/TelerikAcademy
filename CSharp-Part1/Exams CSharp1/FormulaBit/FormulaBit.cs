using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaBit
{
    class FormulaBit
    {
        static void Main(string[] args)
        {
            byte[] formulaBit = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                formulaBit[i]=byte.Parse(Console.ReadLine());
            }
            string direction = "down";
            int countDirections = 0;
            int countMoves = 1;
            int col = 0;
            int row = 0;
            bool success = true;
            int upOrDown = 0;

            while(true)
			{
                if (col == 7 & row == 7)
                {
                    success = true;
                    break;
                }
                int mask = 1 << col;

                if (row == 0 && col == 0)
                {
                    if ((formulaBit[col] & mask) >> col == 1)
                    {
                        success = false;
                        countMoves = 0;
                        break;
                    }
                }

                if (countDirections % 2 == 0)
                {
                    if (countDirections % 4 == 0)
                    {
                        direction = "down";
                    }
                    else
                    {
                        direction = "up";
                    }
                }
                else
                {
                    direction = "left";
                }

                

                if (direction == "down")
                {
                    if (row + 1 < 8)
                    {
                        if ((formulaBit[row + 1] & mask) >> col == 1)
                        {
                            mask = 1 << col + 1;
                            if (col + 1 > 7 || (formulaBit[row] & mask) >> col + 1 == 1)
                            {
                                success = false;
                                break;
                            }
                            else
                            {
                                countMoves++;
                                col++;
                                countDirections++;
                                upOrDown++;
                                continue;
                            }
                        }
                        else
                        {
                            countMoves++;
                            row++;
                            continue;
                        }
                    }
                    else
                    {
                        mask = 1 << col + 1;
                        if (col + 1 > 7 || (formulaBit[row] & mask) >> col + 1 == 1)
                        {
                            success = false;
                            break;
                        }
                        else
                        {
                            countMoves++;
                            col++;
                            countDirections++;
                            upOrDown++;
                            continue;
                        }
                    }
                }
                if(direction == "up")
                {
                    if (row - 1 >= 0)
                    {
                        if ((formulaBit[row - 1] & mask) >> col == 1)
                        {
                            mask = 1 << col + 1;
                            if (col + 1 > 7 || (formulaBit[row] & mask) >> col + 1 == 1)
                            {
                                success = false;
                                break;
                            }
                            else
                            {
                                countMoves++;
                                col++;
                                countDirections++;
                                upOrDown++;
                                continue;
                            }
                        }
                        else
                        {
                            countMoves++;
                            row--;
                            continue;
                        }
                    }
                    else
                    {
                        mask = 1 << col + 1;
                        if (col + 1 > 7 || (formulaBit[row] & mask) >> col + 1 == 1)
                        {
                            success = false;
                            break;
                        }
                        else
                        {
                            countMoves++;
                            col++;
                            countDirections++;
                            upOrDown++;
                            continue;
                        }
                    }
                }

                if (direction == "left")
                {
                    int changeDirection = 0;
                    if (upOrDown % 2 == 0) //down
                    {
                        changeDirection = 1;
                    }
                    else//up
                    {
                        changeDirection = -1;
                    }
                    if (col + 1 < 8)
                    {
                        mask = 1 << col + 1;
                        if ((formulaBit[row] & mask) >> col + 1 == 1)
                        {
                            mask = 1 << col;
                            if (row + changeDirection > 7 || row + changeDirection < 0 || (formulaBit[row + changeDirection] & mask) >> col == 1)
                            {
                                success = false;
                                break;
                            }
                            else
                            {
                                countMoves++;
                                row += changeDirection;
                                countDirections++;
                                continue;
                            }
                        }
                        else
                        {
                            countMoves++;
                            col++;
                            continue;
                        }
                    }
                    else
                    {
                        mask = 1 << col;
                        if (row + changeDirection < 8 || row + changeDirection >= 0)
                        {
                            if ((formulaBit[row + changeDirection] & mask) >> col == 1)
                            {
                                success = false;
                                break;
                            }
                            else
                            {
                                countMoves++;
                                row += changeDirection;
                                countDirections++;
                                continue;
                            }
                        }
                    }
                }
            }
            if (success)
            {
                Console.WriteLine(countMoves + " " + countDirections);
            }
            else
            {
                Console.WriteLine("No " + countMoves);
            }
        }
    }
}

