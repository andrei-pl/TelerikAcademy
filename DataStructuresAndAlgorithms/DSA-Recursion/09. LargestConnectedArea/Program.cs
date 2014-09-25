namespace _09.LargestConnectedArea
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Write a recursive program to find the largest connected area of adjacent empty cells in a matrix.
    /// </summary>
    class Program
    {
        internal static bool existPath = false;

        public static char[,] labyrinth;

        public static void Main()
        {
            labyrinth = new char[,]
            {
                {' ', ' ', '*', ' ', ' ', ' ', '*', '*', ' ', ' '},
                {'*', ' ', '*', ' ', ' ', '*', ' ', ' ', '*', ' '},
                {' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' ', ' '},
                {' ', '*', '*', '*', ' ', '*', ' ', '*', '*', ' '},
                {' ', ' ', ' ', '*', ' ', '*', '*', ' ', ' ', '*'},
            };

            Tuple<int, int> startPosition;
            List<Tuple<int, int>> maxPath = new List<Tuple<int, int>>();
            List<Tuple<int, int>> currentPath = new List<Tuple<int, int>>();
            int count;
            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for (int j = 0; j < labyrinth.GetLength(1); j++)
                {
                    count = 0;
                    startPosition = new Tuple<int, int>(i, j);
                    if (IsInRange(new Tuple<int, int>(i - 1, j)) && labyrinth[i - 1, j] == ' ')
                    {
                        count++;
                    }

                    if (IsInRange(new Tuple<int, int>(i + 1, j)) && labyrinth[i + 1, j] == ' ')
                    {
                        count++;
                    }

                    if (IsInRange(new Tuple<int, int>(i, j - 1)) && labyrinth[i, j - 1] == ' ')
                    {
                        count++;
                    }

                    if (IsInRange(new Tuple<int, int>(i, j + 1)) && labyrinth[i, j + 1] == ' ')
                    {
                        count++;
                    }

                    if (count == 1 && labyrinth[i,j] == ' ')
                    {
                        FindAllPaths(startPosition, currentPath);
                        //PrintPath(currentPath);  //display all paths
                        if (currentPath.Count > maxPath.Count)
                        {
                            maxPath = new List<Tuple<int, int>>(currentPath);
                        }
                        currentPath.Clear();
                    }
                }
            }

            Console.WriteLine("Max path is:");
            PrintPath(maxPath);
        }

        public static bool IsInRange(Tuple<int, int> currentPosition)
        {
            if (currentPosition.Item1 < 0 || currentPosition.Item1 >= labyrinth.GetLength(0))
            {
                return false;
            }
            if (currentPosition.Item2 < 0 || currentPosition.Item2 >= labyrinth.GetLength(1))
            {
                return false;
            }

            return true;
        }

        private static void FindAllPaths(Tuple<int, int> currentPosition, List<Tuple<int, int>> currentPath)
        {
            if (IsInRange(currentPosition))
            {
                if (labyrinth[currentPosition.Item1, currentPosition.Item2] != ' ')
                {
                    // The current cell is not free -> can't find a path
                    return;
                }
                
                labyrinth[currentPosition.Item1, currentPosition.Item2] = '*';
                currentPath.Add(currentPosition);
                FindAllPaths(new Tuple<int, int>(currentPosition.Item1 + 1, currentPosition.Item2), currentPath);
                FindAllPaths(new Tuple<int, int>(currentPosition.Item1 - 1, currentPosition.Item2), currentPath);
                FindAllPaths(new Tuple<int, int>(currentPosition.Item1, currentPosition.Item2 + 1), currentPath);
                FindAllPaths(new Tuple<int, int>(currentPosition.Item1, currentPosition.Item2 - 1), currentPath);
            }
        }


        private static void PrintPath(List<Tuple<int, int>> path)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var position in path)
            {
                sb.Append("(");
                sb.Append(position.Item1);
                sb.Append(", ");
                sb.Append(position.Item2);
                sb.Append("), ");
            }

            sb.Remove(sb.Length - 2, 2);
            sb.AppendLine();
            sb.Append("Number of elements in area is:");
            sb.AppendLine(path.Count.ToString());
            Console.WriteLine(sb.ToString());
        }
    }
}
