using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KukataIsDancing
{
    class KukataIsDancing
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            char[][] dance = new char[n][];
            for (int i = 0; i < dance.GetLength(0); i++)
            {
                dance[i] = Console.ReadLine().ToCharArray();
            }
            string[] color = new string[n];

            int dx = 1;
            int dy = 1;
            for (int i = 0; i < dance.GetLength(0); i++)
            {
                dx = 1;
                dy = 1;
                int move = 0;
                char direction = 'F';
                while (move < dance[i].Length)
                {
                    char command = dance[i][move];
                    if (command == 'L')
                    {
                        if (direction == 'F') direction = 'U';
                        else if (direction == 'B') direction = 'D';
                        else if (direction == 'U') direction = 'B';
                        else if (direction == 'D') direction = 'F';
                    }
                    if (command == 'R')
                    {
                        if (direction == 'F') direction = 'D';
                        else if (direction == 'B') direction = 'U';
                        else if (direction == 'U') direction = 'F';
                        else if (direction == 'D') direction = 'B';
                    }
                    if (command == 'W')
                    {
                        NextPosition(command, direction, ref dx, ref dy);
                    }
                    move++;
                }
                if (dx == 1 && dy == 1)
                {
                    color[i] = "GREEN";
                }
                else if ((dx == 0 && dy == 0) || (dx == 2 && dy == 2) || (dx == 0 && dy == 2) || (dx == 2 && dy == 0))
                {
                    color[i] = "RED";
                }
                else
                {
                   color[i] = "BLUE";
                }
            }
            for (int i = 0; i < color.Length; i++)
            {
                Console.WriteLine(color[i]);
            }
        }

        static void NextPosition(char command, char direction, ref int dx, ref int dy)
        {
            if (direction == 'U')
            {
                dy--;
                if (dy < 0)
                {
                    dy = 2;
                }
            }
            if (direction == 'D')
            {
                dy++;
                if (dy > 2)
                {
                    dy = 0;
                }
            }
            if (direction == 'B')
            {
                dx--;
                if (dx < 0)
                {
                    dx = 2;
                }
            }
            if (direction == 'F')
            {
                dx++;
                if (dx > 2)
                {
                    dx = 0;
                }
            }
        }
    }
}
