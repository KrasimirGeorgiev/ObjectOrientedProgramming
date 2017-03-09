namespace Telerik.Homeworks.OOP.Principles.StudentsAndWorkers.Generators
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Principles;

    public abstract class SimpleGenerator<T>
        where T : Human
    {
        private const int MinAge = 10;

        private const int MaxAge = 111;

        private readonly string[] dataSplitPattern = { "\t" };

        private string[] headerLine;

        private string dataFilePath;

        static SimpleGenerator()
        {
            Random = new Random();
        }

        protected SimpleGenerator(
            string txtFilePath = "./Generators/people-data.txt", string[] splitPattern = null)
        {
            this.DataFilePath = txtFilePath;

            if (splitPattern != null)
            {
                this.dataSplitPattern = splitPattern;
            }
        }

        public string[] HeaderLine => this.headerLine.Take(this.headerLine.Count()).ToArray();

        protected static Random Random { get; }

        private string DataFilePath
        {
            set
            {
                if (File.Exists(value))
                {
                    this.dataFilePath = value;
                }
                else
                {
                    Console.WriteLine("Invalid Path, try again: ");
                    this.DataFilePath = Console.ReadLine();
                }
            }
        }

        public IList<T> Generate(int count, int startLine = 1)
        {
            var list = new List<T>();

            using (var textReader = new StreamReader(this.dataFilePath))
            {
                // Set headerLine
                this.headerLine = textReader.ReadLine()?.Split(
                    this.dataSplitPattern, StringSplitOptions.RemoveEmptyEntries);

                // Skip to line
                for (int i = 1; i < startLine; i++)
                {
                    textReader.ReadLine();
                }

                string currentLine;
                while ((currentLine = textReader.ReadLine()) != null && count > 0)
                {
                    count--;

                    string[] data = currentLine.Split(
                        this.dataSplitPattern, StringSplitOptions.RemoveEmptyEntries);

                    // Don't touch it's magic
                    if (data.Length < 4)
                    {
                        continue;
                    }

                    T current = this.GenerateType(data);

                    if (current != null)
                    {
                        list.Add(current);
                    }
                }
            }

            return list;
        }

        protected abstract T GenerateType(string[] data);
    }
}
