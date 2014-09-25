namespace _07.FindPaths
{
    using System;

    /// <summary>
    /// We are given a matrix of passable and non-passable cells. Write a recursive program for finding all paths between two cells in the matrix.
    /// </summary>
    class Program
    {
        static char[,] lab ={
                            {' ', ' ', ' ', '*', ' ', ' ', ' '},
                            {'*', '*', ' ', '*', ' ', '*', ' '},
                            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
                            {' ', '*', '*', '*', '*', '*', ' '},
                            {' ', ' ', ' ', ' ', ' ', ' ', 'е'},
                            };

        static char[] path = new char[lab.GetLength(0) * lab.GetLength(1)];
        static int position = 0;
        static void Main(string[] args)
        {
            FindPath(0, 0, 'S');
        }

        static void FindPath(int row, int col, char direction)
        {
            if ((col < 0) || (row < 0) || (col >= lab.GetLength(1)) || (row >= lab.GetLength(0)))
            {
                return;
            }

            // Append the direction to the path
            path[position] = direction;
            position++;

            // Check if we have found the exit
            if (lab[row, col] == 'е')
            {
                PrintPath(path, 1, position - 1);
            }
            if (lab[row, col] == ' ')
            {
                // The current cell is free. Mark it as visited
                lab[row, col] = 's';

                // Invoke recursion to explore all possible directions
                FindPath(row, col - 1, 'L'); 
                FindPath(row - 1, col, 'U'); 
                FindPath(row, col + 1, 'R'); 
                FindPath(row + 1, col, 'D'); 

                // Mark back the current cell as free
                lab[row, col] = ' ';
            }
            // Remove the direction from the path
            position--;
        }

        static void PrintPath(char[] path, int startPos, int endPos)
        {
            Console.Write("Found path to the exit: ");
            for (int pos = startPos; pos <= endPos; pos++)
            {
                Console.Write(path[pos]);
            }
            Console.WriteLine();
        }
    }
}
