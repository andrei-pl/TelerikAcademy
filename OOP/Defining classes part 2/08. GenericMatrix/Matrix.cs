using System;
using System.Text;

namespace _08.GenericMatrix
{
    class Matrix<T>
    {
        //8. Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals). 

        public T[,] MatrixN { get; private set; }
        public int Rows { get; private set; }
        public int Cols { get; private set; }

        public Matrix(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            MatrixN = new T[rows, cols];
        }

        public Matrix(T[,] matrix)
        {
            MatrixN = new T[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    MatrixN[i, j] = matrix[i, j];
                }
            }
        }

        //9. Implement an indexer this[row, col] to access the inner matrix cells.

        public T this[int i, int j]
        {
            get { return MatrixN[i, j]; }
            set { MatrixN[i, j] = value; }
        }

        //10. Implement the operators + and - (addition and subtraction of matrices of the same size) and * for matrix multiplication. 
        //Throw an exception when the operation cannot be performed. Implement the true operator (check for non-zero elements).

        private static Matrix<T> PlusMinus(Matrix<T> m1, Matrix<T> m2, bool plus)
        {
            if (!(m1.Rows == m2.Rows && m1.Cols == m2.Cols))
            {
                throw new ArgumentException("Matrix size is not the same!");
            }

            Matrix<T> result = new Matrix<T>(m1.Rows, m1.Cols);

            for (int i = 0; i < result.Rows; i++)
            {
                for (int j = 0; j < result.Cols; j++)
                {
                    result[i, j] = m1[i, j] + (plus ? m2[i, j] : -(dynamic)m2[i, j]);
                }
            }

            return result;
        }

        public static Matrix<T> operator +(Matrix<T> m1, Matrix<T> m2)
        {
            return PlusMinus(m1, m2, true);
        }

        public static Matrix<T> operator -(Matrix<T> m1, Matrix<T> m2)
        {
            return PlusMinus(m1, m2, false);
        }

        public static Matrix<T> operator *(Matrix<T> m1, Matrix<T> m2)
        {
            if (!(m1.Cols == m2.Rows))
            {
                throw new ArgumentException("Matrix size is not the same!");
            }

            Matrix<T> result = new Matrix<T>(m1.Rows, m2.Cols);

            for (int i = 0; i < result.Rows; i++)
            {
                for (int j = 0; j < result.Cols; j++)
                {
                    for (int k = 0; k < m1.Cols; k++)
                    {
                        result[i, j] += (dynamic)m1[i, k] * m2[k, j];
                    }
                }
            }
            return result;
        }

        private static bool BoolOperator(Matrix<T> m, bool value)
        {
            foreach (T item in m.MatrixN)
            {
                if ((dynamic)item != 0)
                {
                    return value;
                }
            }
            return !value;
        }

        public static bool operator true(Matrix<T> m)
        {
            return BoolOperator(m, true);
        }

        public static bool operator false(Matrix<T> m)
        {
            return BoolOperator(m, false);
        }

        public override string ToString()
        {
            StringBuilder matrixToString = new StringBuilder();

            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    matrixToString.Append(this.MatrixN[i, j] + " ");
                }
                matrixToString.Append(Environment.NewLine);
            }
            return matrixToString.ToString();
        }
    }
}
