using System;

namespace _06.ClassMatrix
{
    //* Write a class Matrix, to holds a matrix of integers. 
    //Overload the operators for adding, subtracting and multiplying of matrices, indexer for accessing the matrix content and ToString().

    class MatrixAndOverloading
    {
        class Matrix
        {
            int[,] matrix;
            int rows;
            int cols;

            public Matrix(int[,] matrix)
            {
                this.matrix = matrix;
                rows = matrix.GetLength(0);
                cols = matrix.GetLength(1);
            }

            public Matrix(int rows, int cols)
            {
                this.rows = rows;
                this.cols = cols;
                matrix = new int[rows, cols];
            }

            public void Print()
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write(this.matrix[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            public static Matrix operator +(Matrix A, Matrix B)
            {
                Matrix result = new Matrix(A.rows, A.cols);

                if (A.rows != B.rows || A.cols != B.cols)
                {
                    throw new InvalidOperationException("Cannot add matrices from different types.");
                }
                else
                {
                    for (int row = 0; row < result.rows; row++)
                    {
                        for (int col = 0; col < result.cols; col++)
                        {
                            result.matrix[row, col] += A.matrix[row, col] + B.matrix[row, col];
                        }
                    }
                    return result;
                }
            }

            public static Matrix operator -(Matrix A, Matrix B)
            {
                Matrix result = new Matrix(A.rows, A.cols);

                if (A.rows != B.rows || A.cols != B.cols)
                {
                    throw new InvalidOperationException("Cannot subtract matrices from different types.");
                }
                else
                {
                    for (int row = 0; row < result.rows; row++)
                    {
                        for (int col = 0; col < result.cols; col++)
                        {
                            result.matrix[row, col] += A.matrix[row, col] - B.matrix[row, col];
                        }
                    }
                    return result;
                }
            }


            public static Matrix operator *(Matrix A, Matrix B)
            {
                Matrix result = new Matrix(A.rows, B.cols);

                if (A.cols != B.rows)
                {
                    throw new InvalidOperationException("Cannot multiply matrices from different types.");
                }
                else
                {
                    for (int row = 0; row < result.rows; row++)
                    {
                        for (int col = 0; col < result.cols; col++)
                        {
                            for (int m = 0; m < A.cols; m++)
                            {
                                result.matrix[row, col] += A.matrix[row, m] * B.matrix[m, col];
                            }
                        }
                    }
                    return result;
                }
            }

            public override string ToString()
            {
                string stringMatrix = "";
                for (int row = 0; row < this.matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < this.matrix.GetLength(1); col++)
                    {
                        stringMatrix += this.matrix[row, col];
                        stringMatrix += " ";
                    }
                    stringMatrix += "\n";
                }
                return stringMatrix;
            }

            public object this[int i, int j]
            {
                get
                {
                    if (i < 0 || j < 0)
                    {
                        throw new System.IndexOutOfRangeException("Cannot work with negative indecies");
                    }
                    return this.matrix[i, j];
                }
                set
                {
                    if (i < 0 || j < 0)
                    {
                        throw new System.IndexOutOfRangeException("Cannot work with negative indecies");
                    }
                    this.matrix[i, j] = (int)value;
                }
            }

            public int[,] Values
            {
                get
                {
                    return this.matrix;
                }
                set
                {
                    this.matrix = value;
                    this.rows = matrix.GetLength(0);
                    this.cols = matrix.GetLength(1);
                }
            }
        }
        static void Main(string[] args)
        {
            int[,] x = new int[,]
        {
            { 1, 2, 3, 4},
            { 5, 6, 7, 8},
            { 9,10,11,12},
            {13,14,15,16},
            {17,18,19,20}
        };
            //testing constructions
            Matrix matrix1 = new Matrix(x); 
            Matrix matrix2 = new Matrix(3,3);

            //testing property values
            matrix2.Values = new int[,]{
            {1, 2, 3, 4},
            {5, 6, 7, 8},
            {9, 10, 11, 12},
            {13, 14, 15, 16}
        };
            matrix1.Print();
            matrix2.Print();

            Matrix matrix3 = new Matrix(
       new int[,]{
                    {10, 11, 12, 13},
                    {14, 15, 16, 17},
                    {18 , 19, 20, 21},
                    {0 , 1, 2, 3}
                 });
            matrix3.Print();

            matrix3.Values = new int[,]{
            {1, 2, 3, 4},
            {5, 6, 7, 8},
            {16, 15, 14, 13},
            {12, 11, 10, 9}
        };
            //testing ToString()
            Console.WriteLine(matrix3.ToString());

            //testing multiplication
            Matrix matrix = matrix1 * matrix2;
            matrix.Print();

            //testing indexer
            matrix[2, 2] = 2;
            Console.WriteLine(matrix[2, 2]);
            Console.WriteLine();

            //testing addition
            matrix = matrix2 + matrix3;
            matrix.Print();

            //testing subtraction
            matrix = matrix2 - matrix3;
            matrix.Print();
        }
    }
}
