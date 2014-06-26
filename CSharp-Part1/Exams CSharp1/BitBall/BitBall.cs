using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBall
{
    class BitBall
    {
        static void Main(string[] args)
        {
            byte[] player1 = new byte[8];
            byte[] player2 = new byte[8];
            byte[] gameField = new byte[8];

            int scorePlayer1 = 0;
            int scorePlayer2 = 0;

            for (int i = 0; i < player1.Length; i++)
            {
                player1[i] = byte.Parse(Console.ReadLine());
            }
            for (int i = 0; i < player2.Length; i++)
            {
                player2[i] = byte.Parse(Console.ReadLine());
                gameField[i] = (byte)(player1[i] | player2[i]);
            }
            for (int i = 0; i < gameField.Length; i++)
            {
                byte temp;
                gameField[i] = (byte)(player1[i] ^ player2[i]);
                temp = player1[i];
                player1[i] = (byte)(player1[i] & ~player2[i]);
                player2[i] = (byte)(player2[i] & ~temp);
            }
            for (int col = 0; col < gameField.Length; col++)
            {
               int mask = 1 << col;
                
                int row = 0;
                
                while (true)
                {
                    if ((gameField[row] & mask) >> col == 1)
                    {
                        if ((player1[row] & mask) >> col == 1)
                        {
                            if (row + 1 < 8)
                            {
                                if ((gameField[row + 1] & mask) >> col == 0)
                                {
                                    gameField[row + 1] = (byte)(gameField[row + 1] | mask);
                                    gameField[row] = (byte)(gameField[row] & ~mask);
                                    player1[row + 1] = (byte)(player1[row + 1] | mask);
                                    player1[row] = (byte)(player1[row] & ~mask);
                                    row++;
                                }
                                else
                                {
                                    if (row < 7)
                                    {
                                        row++;
                                        continue;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                scorePlayer1++;
                                break;
                            }
                        }
                        else
                        {
                            if (row - 1 >= 0)
                            {
                                if ((gameField[row - 1] & mask) >> col == 0)
                                {
                                    gameField[row - 1] = (byte)(gameField[row - 1] | mask);
                                    gameField[row] = (byte)(gameField[row] & ~mask);
                                    player2[row - 1] = (byte)(player2[row - 1] | mask);
                                    player2[row] = (byte)(player2[row] & ~mask);

                                    row--;
                                }
                                else
                                {
                                    if (row < 7)
                                    {
                                        row++;
                                        continue;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                scorePlayer2++;
                                row++;
                                continue;
                            }
                        }
                    }
                    else
                    {
                        if (row == 7)
                        {
                            break;
                        }
                        row++;
                    }
                }
            }
            Console.WriteLine(scorePlayer1 + ":" + scorePlayer2);
        }
    }
}
