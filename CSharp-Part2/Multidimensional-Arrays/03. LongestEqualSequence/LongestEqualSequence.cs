using System;

namespace _03.LongestEqualSequence
{
    //We are given a matrix of strings of size N x M. 
    //Sequences in the matrix we define as sets of several neighbor elements located on the same line, column or diagonal. 
    //Write a program that finds the longest sequence of equal strings in the matrix. 
    //Example:  ha fifi ho hi                   s  qq s
    //          fo  ha  hi xx  -> ha, ha, ha    pp pp s -> s, s, s
    //          xxx ho  ha xx                   pp qq s

    class LongestEqualSequence
    {
        static int maxDirection = 0;
        static string maxString = "";
           
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of rows:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number of columns:");
            int m = int.Parse(Console.ReadLine());

            Console.WriteLine("Write values like normal matrix:");
            string[,] matrix = new string[n, m];
            for (int i = 0; i < matrix.GetLength(0); ++i)  //Write values like normal matrix
            {
                string text = Console.ReadLine();
                string[] separators = new string[]{" ", "\t"};
                string[] textArray = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    matrix[i, j] = textArray[j];
                }
            }

            RightOrDownCheck(matrix, matrix.GetLength(0), matrix.GetLength(1), "right");
            RightOrDownCheck(matrix, matrix.GetLength(1), matrix.GetLength(0), "down");
            RightORLeftDiagonal(matrix, matrix.GetLength(0) - 1, matrix.GetLength(1) - 1);
            RightORLeftDiagonal(matrix, matrix.GetLength(0) - 1, 0);

            for (int i = 0; i < maxDirection; i++)
            {
                Console.Write(maxString + " ");
            }
        }

        static void RightOrDownCheck(string[,] matrix, int firstDirection, int secondDirection, string direction)
        {
            string currentString = "";

            if (matrix.GetLength(0) > 0 && matrix.GetLength(1) > 0)
            {
                currentString = matrix[0, 0];
            }
            int currentDirection = 1;

            for (int i = 0; i < firstDirection; i++)
            {
                currentDirection = 1;
                if (direction == "right")
                {
                    currentString = matrix[i, 0];
                }
                else
                {
                    currentString = matrix[0, i];
                }
                for (int j = 0; j < secondDirection - 1; j++)
                {
                    if (direction == "right")
                    {
                        if (currentString.Equals(matrix[i, j + 1]))
                        {
                            currentDirection++;
                        }
                        else
                        {
                            if (maxDirection < currentDirection)
                            {
                                maxDirection = currentDirection;
                                maxString = currentString;
                            }
                            currentDirection = 1;
                            currentString = matrix[i, j + 1];
                        }
                    }
                    else
                    {
                        if (currentString.Equals(matrix[j + 1, i]))
                        {
                            currentDirection++;
                        }
                        else
                        {
                            if (maxDirection < currentDirection)
                            {
                                maxDirection = currentDirection;
                                maxString = currentString;
                            }
                            currentDirection = 1;
                            currentString = matrix[j + 1, i];
                        }
                    }
                }
                if (maxDirection < currentDirection)
                {
                    maxDirection = currentDirection;
                    maxString = currentString;
                }
            }
        }
        static void RightORLeftDiagonal(string[,] matrix, int firstDirection, int secondDirection)
        {
            string currentString = "";
            int row = firstDirection;
            int col = secondDirection;

            if (matrix.GetLength(0) > 0 && matrix.GetLength(1) > 0)
            {
                currentString = matrix[row, col];
            }
            int currentDirection = 1;
            if (secondDirection > 0)
            {
                while (firstDirection > 0)
                {
                    currentString = matrix[row, col];
                    while (col >= 0)
                    {
                        if (row + 1 == matrix.GetLength(0) || col - 1 < 0)
                        {
                            break;
                        }
                        if (matrix[row, col].Equals(matrix[row + 1, col - 1]))
                        {
                            currentDirection++;
                        }
                        else
                        {
                            if (currentDirection > maxDirection)
                            {
                                maxDirection = currentDirection;
                                maxString = currentString;
                            }
                            currentDirection = 1;
                            currentString = matrix[row + 1, col - 1];
                        }
                        col--;
                        row++;
                    }
                    if (currentDirection > maxDirection)
                    {
                        maxDirection = currentDirection;
                        maxString = currentString;
                    }
                    firstDirection--;
                    col = secondDirection;
                    row = firstDirection;
                    currentDirection = 1;
                }
                while (secondDirection >= 0)
                {
                    currentString = matrix[row, col];

                    while (row < matrix.GetLength(0))
                    {
                        if (row + 1 == matrix.GetLength(0) || col - 1 < 0)
                        {
                            break;
                        }
                        if (matrix[row, col].Equals(matrix[row + 1, col - 1]))
                        {
                            currentDirection++;
                        }
                        else
                        {
                            if (currentDirection > maxDirection)
                            {
                                maxDirection = currentDirection;
                                maxString = currentString;
                            }
                            currentDirection = 1;
                            currentString = matrix[row + 1, col - 1];
                        }
                        col--;
                        row++;
                    }
                    if (currentDirection > maxDirection)
                    {
                        maxDirection = currentDirection;
                        maxString = currentString;
                    }
                    secondDirection--;
                    col = secondDirection;
                    row = firstDirection;
                    currentDirection = 1;
                }
            }
            else
            {
                while (firstDirection > 0)
                {
                    currentString = matrix[row, col];
                    while (col < matrix.GetLength(1))
                    {
                        if (row + 1 == matrix.GetLength(0) || col + 1 == matrix.GetLength(1))
                        {
                            break;
                        }
                        if (matrix[row, col].Equals(matrix[row + 1, col + 1]))
                        {
                            currentDirection++;
                        }
                        else
                        {
                            if (currentDirection > maxDirection)
                            {
                                maxDirection = currentDirection;
                                maxString = currentString;
                            }
                            currentDirection = 1;
                            currentString = matrix[row + 1, col + 1];
                        }
                        col++;
                        row++;
                    }
                    if (currentDirection > maxDirection)
                    {
                        maxDirection = currentDirection;
                        maxString = currentString;
                    }
                    firstDirection--;
                    col = secondDirection;
                    row = firstDirection;
                    currentDirection = 1;
                }
                while (secondDirection < matrix.GetLength(1))
                {
                    currentString = matrix[row, col];

                    while (row < matrix.GetLength(0))
                    {
                        if (row + 1 == matrix.GetLength(0) || col + 1 == matrix.GetLength(1))
                        {
                            break;
                        }
                        if (matrix[row, col].Equals(matrix[row + 1, col + 1]))
                        {
                            currentDirection++;
                        }
                        else
                        {
                            if (currentDirection > maxDirection)
                            {
                                maxDirection = currentDirection;
                                maxString = currentString;
                            }
                            currentDirection = 1;
                            currentString = matrix[row + 1, col + 1];
                        }
                        col++;
                        row++;
                    }
                    if (currentDirection > maxDirection)
                    {
                        maxDirection = currentDirection;
                        maxString = currentString;
                    }
                    secondDirection++;
                    col = secondDirection;
                    row = firstDirection;
                    currentDirection = 1;
                }
            }
        }
    }
}
