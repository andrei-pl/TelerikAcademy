using System;

namespace _07.LargestAreaOfEqualElements
{
    //* Write a program that finds the largest area of equal neighbor elements in a rectangular matrix and prints its size.

    class LargestAreaOfEqualElements
    {
        static int currentNumber = 0;
        static int currentSum = 0;
        static int maxSum = 0;

        static void Main(string[] args)
        {
            int[,] matrix = { 
                            { 1, 3, 2, 2, 2, 4 }, 
                            { 3, 3, 3, 2, 4, 4 }, 
                            { 4, 3, 1, 2, 3, 3 }, 
                            { 4, 3, 1, 3, 3, 1 }, 
                            { 4, 3, 3, 3, 1, 1 } 
                            };

            int[,] temporaryMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];  //matrix for printing the path of the largest area

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    currentNumber = matrix[i, j];
                    FindArea(matrix, i, j, ref temporaryMatrix);

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                    }
                    currentSum = 0;
                    isCleared = false;
                }
            }

            Console.WriteLine("The largest area of equal neighbor elements is with size: " + maxSum);
            for (int i = 0; i < temporaryMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < temporaryMatrix.GetLength(1); j++)
                {
                    Console.Write(temporaryMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static bool isCleared = false;   //whether the temporary matrix is cleared before enter the new path

        static void FindArea(int[,] matrix, int row, int col, ref int[,] tempMatrix)
        {

            if (row < 0 || col < 0 || row == matrix.GetLength(0) || col == matrix.GetLength(1))
            {
                return;
            }
            if (matrix[row, col] != currentNumber)
            {
                return;
            }
            
            currentSum++;
            matrix[row, col] = 0;

            FindArea(matrix, row - 1, col, ref tempMatrix);
            FindArea(matrix, row, col - 1, ref tempMatrix);
            FindArea(matrix, row, col + 1, ref tempMatrix);
            FindArea(matrix, row + 1, col, ref tempMatrix);
            matrix[row, col] = currentNumber;
            if (currentSum > maxSum)
            {
                if (isCleared == false)
                {
                    tempMatrix = new int[tempMatrix.GetLength(0), tempMatrix.GetLength(1)];
                    isCleared = true;
                }
                tempMatrix[row, col] = currentNumber;
            }
        }
    }
}
