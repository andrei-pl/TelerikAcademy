using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tron_3D
{
    class Tron3D
    {
        static void Main(string[] args)
        {
            int[] xyz = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int x = xyz[0];
            int y = xyz[1];
            int z = xyz[2];

            string red = Console.ReadLine();
            string blue = Console.ReadLine();

            bool[,] matrix = new bool[x + 1, 2 * y + 2 * z];
            int[] positionRed = { x / 2, y / 2 };
            int[] positionBlue = { x / 2, y + z + y / 2};
            matrix[positionRed[0], positionRed[1]] = matrix[positionBlue[0], positionBlue[1]] = true;

            int[] currentPositionRed = new int[2]; Array.Copy(positionRed, currentPositionRed, positionRed.Length);
            int[] currentPositionBlue = new int[2]; Array.Copy(positionBlue, currentPositionBlue, positionBlue.Length);
            int counterRed = 0;
            int counterBlue = 0;
            char commandRed;
            char commandBlue;
            char directionRed = 'F';
            char directionBlue = 'B';

            while (counterRed < red.Length && counterBlue < blue.Length)                                 //M -> F B U D;
            {                                                                                             //L -> F->U B->D U->L D->R
                commandRed = red[counterRed];                                                                //R -> F->D B->U U->R D->L
                commandBlue = blue[counterBlue];

                if (commandRed == 'L')                                               //while commandRed == 'L' || commandRed = 'R'
                {                                                                    //
                    if (directionRed == 'F') directionRed = 'U';                     //
                    else if (directionRed == 'B') directionRed = 'D';                //
                    else if (directionRed == 'U') directionRed = 'B';                //
                    else if(directionRed == 'D') directionRed = 'F';                 //
                    counterRed++;                                                    //
                    commandRed = red[counterRed];                                    //
                }                                                                    //
                if (commandRed == 'R')                                               //
                {                                                                    //
                    if (directionRed == 'F') directionRed = 'D';                     //
                    else if (directionRed == 'B') directionRed = 'U';                //
                    else if (directionRed == 'U') directionRed = 'F';                //
                    else if (directionRed == 'D') directionRed = 'B';                //
                    counterRed++;                                                    //
                    commandRed = red[counterRed];                                    //                           
                }                                                                    //
                if (commandBlue == 'L')
                {
                    if (directionBlue == 'F') directionBlue = 'U';
                    else if (directionBlue == 'B') directionBlue = 'D';
                    else if (directionBlue == 'U') directionBlue = 'B';
                    else if (directionBlue == 'D') directionBlue = 'F';
                    counterBlue++;
                    commandBlue = blue[counterBlue];          
                }
                if (commandBlue == 'R')
                {
                    if (directionBlue == 'F') directionBlue = 'D';
                    else if (directionBlue == 'B') directionBlue = 'U';
                    else if (directionBlue == 'U') directionBlue = 'F';
                    else if (directionBlue == 'D') directionBlue = 'B';
                    counterBlue++;
                    commandBlue = blue[counterBlue];      
                }
                bool isTrueRed = true;
                bool isTrueBlue = true;

                if (commandRed == 'M' || commandBlue == 'M')
                {
                    if (commandRed == 'M')
                    {
                        isTrueRed = CheckIsEmpty(ref matrix, directionRed, ref positionRed, ref isRedLoose);
                    }
                    if (commandBlue == 'M')
                    {
                        isTrueBlue = CheckIsEmpty(ref matrix, directionBlue, ref positionBlue, ref isBlueLoose);
                    }
                    if (isTrueRed && !isTrueBlue)
                    {
                        if (positionRed[0] == positionBlue[0] && positionRed[1] == positionBlue[1])
                        {
                            isRedLoose = true;
                        }
                        break;
                    }
                }
                
                if (!isTrueRed || !isTrueBlue)
                {
                    break;
                }
                counterRed++;
                counterBlue++;
            }
            int movesRed = 0;
            int movesBlue = 0;
            movesRed = counterMoves(positionRed, currentPositionRed, movesRed, matrix);
            movesBlue = counterMoves(positionBlue, currentPositionBlue, movesBlue, matrix);
            if (isRedLoose && isBlueLoose)
            {
                Console.WriteLine("DRAW");
            }
            else if (isRedLoose && !isBlueLoose)
            {
                Console.WriteLine("BLUE");
            }
            else
            {
                Console.WriteLine("RED");
            }
            //if (movesRed <= movesBlue)
            //{
            
                Console.WriteLine(movesRed);
            //}
            //else
            //{
            //    Console.WriteLine(movesBlue);
            //}
        }

        private static int counterMoves(int[] position, int[] currentPosition, int moves, bool[,] matrix)
        {
            if (currentPosition[1] > position[1])
            {
                while (currentPosition[1] != position[1])
                {
                    currentPosition[1]--;
                    moves++;
                }
            }
            else if (currentPosition[1] < position[1])
            {
                while (currentPosition[1] != position[1])
                {
                    currentPosition[1]++;
                    moves++;
                }
            }
            if (matrix.GetLength(1) - moves < moves)
            {
                moves = matrix.GetLength(1) - moves;
            }
            
            if (currentPosition[0] > position[0])
            {
                while (currentPosition[0] != position[0])
                {
                    currentPosition[0]--;
                    moves++;
                }
            }
            else if (currentPosition[0] < position[0])
            {
                while (currentPosition[0] != position[0])
                {
                    currentPosition[0]++;
                    moves++;
                }
            }
            return moves;
        }

        static bool isRedLoose = false;
        static bool isBlueLoose = false;

        static bool CheckIsEmpty(ref bool[,] matrix, char direction, ref int[] position, ref bool isLoose)
        {
            if (direction == 'F')
            {
                if (position[1] + 1 < matrix.GetLength(1))
                {
                    if (matrix[position[0], position[1] + 1] == true)
                    {
                        position[1]++;
                        isLoose = true;
                        return false;
                    }
                    else
                    {
                        position[1]++;
                        matrix[position[0], position[1]] = true;
                    }
                }
                else
                {
                    if (matrix[position[0], 0] == true)
                    {
                        position[1] = 0;
                        isLoose = true;
                        return false;
                    }
                    else
                    {
                        position[1] = 0;
                        matrix[position[0], position[1]] = true;
                    }
                }
            }
            else if (direction == 'B')
            {
                if (position[1] - 1 >= 0)
                {
                    if (matrix[position[0], position[1] - 1] == true)
                    {
                        position[1]--;
                        isLoose = true;
                        return false;
                    }
                    else
                    {
                        position[1]--;
                        matrix[position[0], position[1]] = true;
                    }
                }
                else
                {
                    if (matrix[position[0], matrix.GetLength(1) - 1] == true)
                    {
                        position[1] = matrix.GetLength(1) - 1;
                        isLoose = true;
                        return false;
                    }
                    else
                    {
                        position[1] = matrix.GetLength(1) - 1;
                        matrix[position[0], position[1]] = true;
                    }
                }
            }
            else if (direction == 'U')
            {
                if (position[0] - 1 >= 0)
                {
                    if (matrix[position[0] - 1, position[1]] == true)
                    {
                        position[0]--;
                        isLoose = true;
                        return false;
                    }
                    else
                    {
                        position[0]--;
                        matrix[position[0], position[1]] = true;
                    }
                }
                else
                {
                    isLoose = true;
                    return false;
                }
            }
            else if (direction == 'D')
            {
                if (position[0] + 1 < matrix.GetLength(0))
                {
                    if (matrix[position[0] + 1, position[1]] == true)
                    {
                        position[0]++;
                        isLoose = true;
                        return false;
                    }
                    else
                    {
                        position[0]++;
                        matrix[position[0], position[1]] = true;
                    }
                }
                else
                {
                    isLoose = true;
                    return false;
                }

            }
            return true;
        }
    }
}
