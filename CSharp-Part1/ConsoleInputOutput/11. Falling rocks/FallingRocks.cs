using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _11.Falling_rocks
{
    //Implement the "Falling Rocks" game in the text console. A small dwarf stays at the bottom of the screen and can move left and right (by the arrows keys). 
    //A number of rocks of different sizes and forms constantly fall down and you need to avoid a crash.

    class FallingRocks
    {
        static int dwarfPositionRow;
        static int dwarfPositionColumn;

        static char[,] consoleWindow;                  
        static ConsoleColor[,] rocksColor;
        static ConsoleColor[] colorKind = { ConsoleColor.Blue, ConsoleColor.Yellow, ConsoleColor.Green, ConsoleColor.DarkRed, ConsoleColor.DarkCyan };
       
        static char[] rocks = {'!', '@', '#', '$', '%', '^', '&', '*', '+', ';', '.', '-'};
        static int consoleWidth;
        static int consoleHeight;
        static int score;

        static void Main(string[] args)
        {
            SetGameField();
            ResetGame();
           
            while (true)
            {
                Random random = new Random();
                int randomNumberRocks = random.Next(0, 3);                                //random number of rocks per row

                int[] rockColumn = new int[randomNumberRocks];                              //array of columns which should be rocks

                PutRockInSomeColumn(random, randomNumberRocks, rockColumn);
                
                Console.Clear();

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    MovePlayer(key);
                }

                Falling_Rocks();

                LoadingRocks(random, randomNumberRocks, rockColumn);

                Console.SetCursorPosition(dwarfPositionColumn, dwarfPositionRow);
                WriteInConsole('(', ConsoleColor.Magenta);                                    //Moving the dwarf
                WriteInConsole('0', ConsoleColor.Magenta);                                    
                WriteInConsole(')', ConsoleColor.Magenta);                                    
                
                Thread.Sleep(150);          //because of the sleep, the button should not be pressed for a long
            }

        }

        private static void LoadingRocks(Random random, int randomNumberRocks, int[] rockColumns)
        {
            int randomFormRocks;
            int randomColor;

            for (int i = 0; i < consoleWidth; i++)                                       //Loading rocks in the first row by the array rockColumns[]
            {
                randomFormRocks = random.Next(0, 11);
                randomColor = random.Next(0, colorKind.Length);

                consoleWindow[i, 0] = ' ';                                              //Where have no rock is an interval

                for (int j = 0; j < randomNumberRocks; j++)
                {
                    if (i == rockColumns[j])                                          //if the index equals with rockColumn value, then there is rock
                    {
                        consoleWindow[i, 0] = rocks[randomFormRocks];
                    }
                }
                rocksColor[i, 0] = colorKind[randomColor];                              //Different color for each rock
                WriteInConsole(consoleWindow[i, 0], rocksColor[i, 0]);
            }
        }

        private static void Falling_Rocks()                                             //Make rocks falling
        {
            for (int i = consoleHeight - 1; i > 0; i--)
            {
                Console.SetCursorPosition(0, i);
                for (int j = 0; j < consoleWidth; j++)
                {
                    for (int n = 0; n < rocks.Length; n++)
                    {
                        if (i == consoleHeight - 1)
                        {
                            if (consoleWindow[j, i] == rocks[n])
                            {
                                score++;                                                //Score for avoided crash with rocks
                            }
                        }
                        if (consoleWindow[dwarfPositionColumn, dwarfPositionRow - 1] == rocks[n] 
                            || consoleWindow[dwarfPositionColumn + 1, dwarfPositionRow - 1] == rocks[n] 
                            || consoleWindow[dwarfPositionColumn + 2, dwarfPositionRow - 1] == rocks[n])
                        {
                            GameOver();                                                  // If rock is above the dwarf, the game is over
                        }
                    }

                    consoleWindow[j, i] = consoleWindow[j, i - 1];                       //This is the rocks falling 
                    rocksColor[j, i] = rocksColor[j, i - 1];                            //And their colors
                    WriteInConsole(consoleWindow[j, i], rocksColor[j, i]);
                }
            }
        }

        private static void GameOver()                                                  //If key is pressed, start new game
        {
            Console.Beep();
            Console.SetCursorPosition(consoleWidth / 2 - 8, consoleHeight / 3);
            Console.WriteLine("Sorry, you crash!");
            Console.WriteLine("            " + score + " rocks avoided!");
            Console.WriteLine("     Press some key to start again!");
            ConsoleKeyInfo key = Console.ReadKey(true);
            Console.Clear();
            ResetGame();
        }

        private static void PutRockInSomeColumn(Random random, int randomNumberRocks, int[] windowColumns)
        {
            for (int i = 0; i < randomNumberRocks; i++)
            {
                windowColumns[i] = random.Next(0, consoleWidth - 1); ;                   //which column in the consoleWindow array to be filled
            }
        }

        private static void SetGameField()
        {
            Console.WindowHeight = 15;
            Console.BufferHeight = 15;
            consoleHeight = Console.WindowHeight;

            Console.WindowWidth = 40;
            Console.BufferWidth = 40;
            consoleWidth = Console.WindowWidth;
        }

        static void MovePlayer(ConsoleKeyInfo key)
        {
                if (key.Key == ConsoleKey.LeftArrow)                                 //check if the dwarf is inside the area, he's moving.
                {
                    if (dwarfPositionColumn > 0)                                   //if is not, he can't go further in order to avoid exception.
                    {   
                        dwarfPositionColumn--;
                    }
                }
                if (key.Key == ConsoleKey.RightArrow)
                {
                    if (dwarfPositionColumn < Console.WindowWidth - 1)
                    {
                        dwarfPositionColumn++;
                    }
                }
        }

        private static void ResetGame()
        {
            consoleWindow = new char[Console.WindowWidth, Console.WindowHeight];
            rocksColor = new ConsoleColor[Console.WindowWidth, Console.WindowHeight];

            dwarfPositionRow = consoleHeight - 1;
            dwarfPositionColumn = consoleWidth / 2;

            score = 0;
           
        }

        static void WriteInConsole(char rockOrDwarf, ConsoleColor color)
        {
            Console.ForegroundColor = color;                                         //Writing the dwarf and all rocks with different colors each
            Console.Write(rockOrDwarf);
        }
    }
}
