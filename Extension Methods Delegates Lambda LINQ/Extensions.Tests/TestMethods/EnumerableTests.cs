namespace Extensions.Tests.TestMethods
{
    using System.Collections.Generic;
    using System.Linq;
    using ConsoleMio.ConsoleEnhancements;
    using static Common;

    public class EnumerableTests
    {
        public EnumerableTests(ConsoleMio consoleMio)
        {
            this.ConsoleMio = consoleMio;
        }

        public ConsoleMio ConsoleMio { get; }

        public void EnumerableMax()
        {
            IEnumerable<int> intCollection = new[] { 1, 2, 3, 14, 5, 6 };

            this.ConsoleMio
                .WriteLine("Testing IEnumerable<T>.Max()", Info)
                .WriteLine()
                .Write("Working with: [", Info)
                .Write(string.Join(", ", intCollection), Result)
                .WriteLine("]", Info)
                .WriteLine()
                .Write("Max elements is: ", Info)
                .WriteLine(intCollection.Max(), Result);
        }

        public void EnumerableMin()
        {
            IEnumerable<int> intCollection = new[] { 1, 2, 3, 14, -5, 6 };

            this.ConsoleMio
                .WriteLine("Testing IEnumerable<T>.Min()", Info)
                .WriteLine()
                .Write("Working with: [", Info)
                .Write(string.Join(", ", intCollection), Result)
                .WriteLine("]", Info)
                .WriteLine()
                .Write("Min elements is: ", Info)
                .WriteLine(intCollection.Min(), Result);
        }

        public void EnumerableSum()
        {
            IEnumerable<int> intCollection = Enumerable.Repeat(10, 5);

            this.ConsoleMio
                .WriteLine("Testing IEnumerable<T>.Sum()", Info)
                .WriteLine()
                .Write("Working with: [", Info)
                .Write(string.Join(", ", intCollection), Result)
                .WriteLine("]", Info)
                .WriteLine()
                .Write("Total sum is: ", Info)
                .WriteLine(intCollection.Sum(), Result);
        }

        public void EnumerableProduct()
        {
            // IEnumerable<int> intCollection = Enumerable.Repeat(int.MaxValue, 5);
            IEnumerable<double> doubles = Enumerable.Repeat(1.1, 5);

            this.ConsoleMio
                .WriteLine("Testing IEnumerable<T>.Product()", Info)
                .WriteLine()
                .Write("Working with: [", Info)
                .Write(string.Join(", ", doubles), Result)
                .WriteLine("]", Info)
                .WriteLine()
                .Write("The product is: ", Info)
                .WriteLine(doubles.Product(), Result);
        }

        public void EnumerableAverage()
        {
            IEnumerable<decimal> decimalCollection = new[] { 10m, 20, 20, 30 };

            this.ConsoleMio
                .WriteLine("Testing IEnumerable<T>.Average()", Info)
                .WriteLine()
                .Write("Working with: [", Info)
                .Write(string.Join(", ", decimalCollection), Result)
                .WriteLine("]", Info)
                .WriteLine()
                .Write("The average is: ", Info)
                .WriteLine(decimalCollection.Average(), Result);
        }

        public void EnumerableDivisibleBy()
        {
            IEnumerable<int> ints = new[] { 20, 21, 22, 21 * 3 * 7, 1 };

            this.ConsoleMio
                .WriteLine("Testing IEnumerable<int>.DivisibleBy(...)", Info)
                .WriteLine()
                .Write("Working with: [", Info)
                .Write(string.Join(", ", ints), Result)
                .WriteLine("]", Info)
                .WriteLine();

            var result = ints
                .DivisibleBy(7)
                .DivisibleBy(3);

            this.ConsoleMio
                .Write("Devisible by 3 & 7: ", Info)
                .WriteLine(string.Join(", ", result), Result);
        }
    }
}
