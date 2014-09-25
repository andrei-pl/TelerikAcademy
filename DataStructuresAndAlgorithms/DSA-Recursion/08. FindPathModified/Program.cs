namespace _08.FindPathModified
{
    using System;
    using System.Collections.Generic;


    /// <summary>
    /// Modify the above program to check whether a path exists between two cells without finding all possible paths. 
    /// Test it over an empty 100 x 100 matrix.
    /// </summary>
    class Program
    {
        static List<Tuple<int, int>> path = new List<Tuple<int, int>>();

        static void Main()
        {
             char[,] lab = new char[100, 100];

            InitBigLab(lab);

            SetExit(90, 29, lab);

            int startRow = 0;
            int startCol = 0;

            bool found = false;

            FindExit(lab, startRow, startCol, ref found);
        }

        private static void SetExit(int row, int col, char[,] bigLab)
        {
            bigLab[row, col] = 'e';
        }

        private static void InitBigLab(char[,] bigLab)
        {
            for (int i = 0; i < bigLab.GetLength(0); i++)
            {
                for (int k = 0; k < bigLab.GetLength(1); k++)
                {
                    bigLab[i, k] = ' ';
                }
            }
        }

        private static void FindExit(char[,] lab, int startRow, int startCol, ref bool found)
        {
            if (found)
            {
                return;
            }

            if (!IsInLab(lab, startRow, startCol))
            {
                return;
            }

            if (lab[startRow, startCol] == 'e')
            {
                path.Add(new Tuple<int, int>(startRow, startCol));
                Print(path);
                path.RemoveAt(path.Count - 1);
                Console.WriteLine("exit found at (row: {0}, col: {1}) ", startRow, startCol);
                found = true;
            }

            if (lab[startRow, startCol] != ' ')
            {
                return;
            }

            path.Add(new Tuple<int, int>(startRow, startCol));
            lab[startRow, startCol] = 's';

            FindExit(lab, startRow, startCol - 1, ref found); //left recursively
            FindExit(lab, startRow - 1, startCol, ref found); //up recursively
            FindExit(lab, startRow, startCol + 1, ref found); //right recursively
            FindExit(lab, startRow + 1, startCol, ref found); //down recursively

            lab[startRow, startCol] = ' ';
            path.RemoveAt(path.Count - 1);
        }

        private static void Print(List<Tuple<int, int>> path)
        {
            Console.WriteLine("the way to exit is: ");
            foreach (var step in path)
            {
                Console.Write("({0}, {1}) ", step.Item1, step.Item2);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        private static bool IsInLab(char[,] lab, int row, int col)
        {
            bool rowIsInLab = row >= 0 && row < lab.GetLength(0);
            bool colIsInLab = col >= 0 && col < lab.GetLength(1);

            return rowIsInLab && colIsInLab;
        }
    }
}
