using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _05.MaxSubMatrix
{
    //Write a program that reads a text file containing a square matrix of numbers and finds in the matrix 
    //an area of size 2 x 2 with a maximal sum of its elements. 
    //The first line in the input file contains the size of matrix N. Each of the next N lines contain N numbers separated by space. 
    //The output should be a single number in a separate text file. Example:
    //  4
    //  2 3 3 4
    //  0 2 3 4	    ->17
    //  3 7 1 2
    //  4 3 3 2

    class MaxSubMatrix
    {
        static void Main(string[] args)
        {
            StreamReader file = new StreamReader(@"..\..\Matrix.txt");

            int[,] matrix = GetMatrix(file);

            StreamReader result = new StreamReader(@"..\..\result.txt");

            Console.WriteLine("The maximal sum in this matrix is " + result.ReadLine());
            result.Close();
        }

        private static int[,] GetMatrix(StreamReader file)
        {
            using (file)
            {
                int n = int.Parse(file.ReadLine());
                int[,] matrix = new int[n, n];
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    string[] line = file.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    if (line.Length < n || line == null)
                    {
                        throw new ArgumentNullException("Invalid matrix");
                    }
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = int.Parse(line[j]);
                    }
                }
                return matrix;
            }
        }

        private static void MaximalSubMatrix(int[,] matrix)
        {
            StreamWriter result = new StreamWriter(@"..\..\result.txt");
            using (result)
            {
                int maxSum = int.MinValue;
                for (int row = 0; row < matrix.GetLength(0) - 1; row++)
                {
                    for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                    {
                        maxSum = Math.Max(maxSum, matrix[row, col] + matrix[row + 1, col] + matrix[row, col + 1] + matrix[row + 1, col + 1]);
                    }
                }
                result.WriteLine(maxSum);
            }
        }
    }
}
