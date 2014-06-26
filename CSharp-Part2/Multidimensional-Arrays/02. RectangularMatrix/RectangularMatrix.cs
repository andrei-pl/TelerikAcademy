using System;

namespace _02.RectangularMatrix
{
    //Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements.

    class RectangularMatrix
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter N:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter M:");
            int m = int.Parse(Console.ReadLine());
            Random rand = new Random();

            int[,] array = new int[n, m];

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    array[row, col] = rand.Next(1, 101);
                }
            }
            int maxPlatformX = 3;
            int maxPlatformY = 3;

            MaxSumOfPlatform(array, maxPlatformX, maxPlatformY);
        }

        static void MaxSumOfPlatform(int[,] array, int maxPlatformX, int maxPlatformY)
        {
            int maxSum = int.MinValue;
            for (int row = 0; row < array.GetLength(0) - maxPlatformX + 1; row++)
            {
                for (int col = 0; col < array.GetLength(1) - maxPlatformY + 1; col++)
                {
                    int currentSum = 0;
                    for (int platformX = row; platformX < maxPlatformX + row; platformX++)
                    {
                        for (int platformY = col; platformY < maxPlatformY + col; platformY++)
                        {
                            currentSum += array[platformX, platformY];
                        }
                    }
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                    }
                }
            }
            Console.WriteLine("Max sum is: " + maxSum);
        }
    }
}
