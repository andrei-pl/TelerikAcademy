using System;

namespace _01.MatrixA
{
    //Write a program that fills and prints a matrix of size (n, n) as shown below: (examples for n = 4)
    // A: 1 5 9 13   B: 1 8 9 16   C: 7 11 14 16  D: 1 12 11 10
    //    2 6 10 14     2 7 10 15     4 8 12 15      2 13 16 9
    //    3 7 11 15     3 6 11 14     2 5 9 13       3 14 15 8
    //    4 8 12 16     4 5 12 13     1 3 6 10       4  5  6 7

    class Matrix
    {
        static void Main(string[] args)
        {
            Console.Write("Enter matrix length: ");
            int n = Int32.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            MatrixA(matrix, 1);
            Console.WriteLine();
            MatrixB(matrix, 1);
            Console.WriteLine();
            MatrixC(matrix, 1);
            Console.WriteLine();
            MatrixD(n, matrix, 1);
        }

        static void MatrixA(int[,] matrix, int counter)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    matrix[j, i] = counter;
                    counter++;
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void MatrixB(int[,] arr, int counter)
        {
            for (int i = 0; i < arr.GetLength(1); i++)
            {
                if (i % 2 == 0)
                    for (int j = 0; j < arr.GetLength(0); j++)
                    {
                        arr[j, i] = counter;
                        counter++;
                    }
                else
                {
                    for (int j = arr.GetLength(0) - 1; j >= 0; j--)
                    {
                        arr[j, i] = counter;
                        counter++;
                    }
                }
            }
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void MatrixC(int[,] arr, int counter)
        {
            int i = arr.GetLength(0) - 1;
            int j = 0;
            int row = arr.GetLength(0) - 1;
            int column = 0;

            while (j <= arr.GetLength(1))
            {
                i = row;
                j = column;

                if (i == 0)
                {
                    while (j < arr.GetLength(1))
                    {
                        if (i == arr.GetLength(0))
                        {
                            break;
                        }
                        arr[i, j] = counter;
                        i++;
                        j++;
                        counter++;
                    }
                    column++;
                }
                else
                {
                    while (i < arr.GetLength(0))
                    {
                        if (j == arr.GetLength(1))
                        {
                            break;
                        }
                        arr[i, j] = counter;
                        i++;
                        j++;
                        counter++;
                    }
                    row--;
                }


            }

            for (int a = 0; a < arr.GetLength(0); a++)
            {
                for (int b = 0; b < arr.GetLength(1); b++)
                {
                    Console.Write(arr[a, b] + " ");
                }
                Console.WriteLine();
            }
        }

        static void MatrixD(int n, int[,] arr, int counter)
        {
            int start = 0;
            int end = n - 1;

            while (counter <= (n * n))
            {

                for (int i = start; i <= end; i++)
                {
                    if (counter > (n * n))
                    {
                        break;
                    }
                    arr[i, start] = counter;
                    counter++;
                }
                for (int j = start + 1; j <= end; j++)
                {
                    if (counter > (n * n))
                    {
                        break;
                    }
                    arr[end, j] = counter;
                    counter++;
                }
                for (int i = end - 1; i >= start; i--)
                {
                    if (counter > (n * n))
                    {
                        break;
                    }
                    arr[i, end] = counter;
                    counter++;
                }
                for (int j = end - 1; j >= start + 1; j--)
                {
                    if (counter > (n * n))
                    {
                        break;
                    }
                    arr[start, j] = counter;
                    counter++;
                }

                start += 1;
                end -= 1;
            }

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
