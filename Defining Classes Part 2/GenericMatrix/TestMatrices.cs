namespace GenericMatrix
{
    using System;
    using System.Reflection;
    using ConsoleMio.ConsoleEnhancements;
    using VersionAttribute;

    [SpecialVersion(1, 101)]
    class TestMatrices
    {
        private const ConsoleColor Info = ConsoleColor.DarkRed;
        private const ConsoleColor Result = ConsoleColor.DarkBlue;
        private const ConsoleColor Pause = ConsoleColor.Black;

        private static readonly ConsoleMio ConsoleMio = new ConsoleMio();

        private static readonly Random Random = new Random();

        static void Main()
        {
            ConsoleMio.PrintHeading("Homework: Defining Classes Part 2 - Generic Matrix");

            var version = typeof(TestMatrices).GetCustomAttribute<SpecialVersionAttribute>(false);

            ConsoleMio
                .Write("Version Information: ", color: Info)
                .WriteLine(version, color: Result)
                .WriteLine();

            Matrix<double> realMatrix = GenerateMatrix(3, 3);
            PrintMatrix(realMatrix);
        }

        private static void PrintMatrix<T>(Matrix<T> matrix) where T : struct, IComparable
        {
            var type = typeof(T).Name;
            ConsoleMio
                .Write(type, color: Result)
                .Write(" matrix of ", color: Info)
                .WriteLine($"{matrix.Rows} x {matrix.Cols}", color: Result)
                .WriteLine(matrix, color: Result)
                .WriteLine();
        }

        private static Matrix<double> GenerateMatrix(int rows, int cols)
        {
            ConsoleMio
                .Write("Generating a ", color: Info)
                .Write($"{rows} x {cols} ", color: Result)
                .WriteLine("matrix", color: Info)
                .WriteLine();

            var matrix = new Matrix<double>(rows, cols);

            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Cols; j++)
                {
                    matrix[i, j] = Math.Round(Random.NextDouble() * 100) / 10;
                }
            }

            return matrix;
        }
    }
}
