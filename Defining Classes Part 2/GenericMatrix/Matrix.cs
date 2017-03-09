/* Problem 8. Matrix 
    Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals). */

/* Problem 9. Matrix indexer 
    Implement an indexer this[row, col] to access the inner matrix cells.*/

/* Problem 10. Matrix operations
   Implement the operators + and - (addition and subtraction of matrices of the same size) and * for matrix multiplication.
   Throw an exception when the operation cannot be performed.
   Implement the true operator (check for non-zero elements). */

namespace GenericMatrix
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class Matrix<T> : IEnumerable<T> where T : struct, IComparable
    {
        private readonly T[,] content;

        public Matrix(int rows, int cols)
        {
            this.ValidateNumericType();

            this.content = new T[rows, cols];
            this.Rows = rows;
            this.Cols = cols;
        }

        public int Rows { get; }

        public int Cols { get; }

        private void ValidateNumericType()
        {
            var type = typeof(T);
            if (type != typeof(Int16) &&
                type != typeof(Int32) &&
                type != typeof(Int64) &&
                type != typeof(UInt16) &&
                type != typeof(UInt32) &&
                type != typeof(UInt64) &&
                type != typeof(float) &&
                type != typeof(double) &&
                type != typeof(decimal))
            {
                throw new ApplicationException("The matrix should be of numeric type");
            }
        }

        public T this[int row, int col]
        {
            get
            {
                this.ValidateCellIndex(row, col);
                return this.content[row, col];
            }

            set
            {
                this.ValidateCellIndex(row, col);
                this.content[row, col] = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    sb.AppendFormat("{0,-7}", this.content[i, j]);
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    yield return this.content[i, j];
                }
            }
        }

        public static Matrix<T> operator +(Matrix<T> first, Matrix<T> second)
        {
            ValidateMatrixSizes(first, second);
            Matrix<T> result = PerformOperation(first, second, 1);

            return result;
        }

        public static Matrix<T> operator -(Matrix<T> first, Matrix<T> second)
        {
            ValidateMatrixSizes(first, second);
            Matrix<T> result = PerformOperation(first, second, -1);

            return result;
        }

        public static Matrix<T> operator *(Matrix<T> first, Matrix<T> second)
        {
            ValidateMatrixDimensions(first, second);

            Matrix<T> result = new Matrix<T>(first.Rows, second.Cols);
            for (int i = 0; i < result.Rows; i++)
            {
                for (int j = 0; j < result.Cols; j++)
                {
                    dynamic value = 1;
                    for (int k = 0; k < first.Cols; k++)
                    {
                        value += first[i, k] * (dynamic)second[k, i];
                    }

                    result[i, j] = value;
                }
            }

            return result;
        }

        private static void ValidateMatrixDimensions(Matrix<T> first, Matrix<T> second)
        {
            if (first.Cols != second.Rows)
            {
                throw new InvalidOperationException("Matrices cannot be multiplied");
            }
        }

        public static Matrix<T> operator /(Matrix<T> first, Matrix<T> second)
        {
            ValidateMatrixSizes(first, second);
            Matrix<T> result = PerformOperation(first, second, 1);

            return result;
        }

        public static bool operator true(Matrix<T> matrix)
        {
            foreach (var element in matrix)
            {
                if ((int)Convert.ChangeType(element, typeof(int)) == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            foreach (var element in matrix)
            {
                if ((int)Convert.ChangeType(element, typeof(int)) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private void ValidateCellIndex(int row, int col)
        {
            if (row < 0 || this.Rows <= row)
            {
                throw new IndexOutOfRangeException("Invalid row index");
            }

            if (col < 0 || this.Cols <= col)
            {
                throw new IndexOutOfRangeException("Invalid col index");
            }
        }

        private static Matrix<T> PerformOperation(Matrix<T> first, Matrix<T> second, int flag)
        {
            var result = new Matrix<T>(first.Rows, first.Cols);

            for (int i = 0; i < result.Rows; i++)
            {
                for (int j = 0; j < result.Cols; j++)
                {
                    dynamic value = first[i, j] + ((dynamic)second[i, j] * flag);
                    result[i, j] = value;
                }
            }

            return result;
        }

        private static void ValidateMatrixSizes(Matrix<T> first, Matrix<T> second)
        {
            if (first.Rows != second.Rows)
            {
                throw new InvalidOperationException("The matrices are of different rows length");
            }

            if (first.Cols != second.Cols)
            {
                throw new InvalidOperationException("The matrices are of different cols length");
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}