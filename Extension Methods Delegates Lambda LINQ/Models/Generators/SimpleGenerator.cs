namespace Models.Generators
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class SimpleGenerator
    {
        private const int MinAge = 10;

        private const int MaxAge = 111;

        private const int MinGroup = 1;

        private const int MaxGroup = 6;

        private static readonly Random Random = new Random();

        private static int nextStudentId = 1;

        private string[] headerLine;

        private string dataFilePath;

        private string[] dataSplitPattern = { "\t" };

        public SimpleGenerator(
            string txtFilePath = "./Generators/students-data.txt", string[] splitPattern = null)
        {
            this.DataFilePath = txtFilePath;

            if (splitPattern != null)
            {
                this.dataSplitPattern = splitPattern;
            }
        }

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
                    Console.WriteLine("Invlaid Path, try again: ");
                    this.DataFilePath = Console.ReadLine();
                }
            }
        }

        public string[] HeaderLine
        {
            get
            {
                return this.headerLine.Take(this.headerLine.Count()).ToArray();
            }
        }

        public IList<Student> Generate(int count, int startLine = 1)
        {
            var list = new List<Student>();

            using (var textReader = new StreamReader(this.dataFilePath))
            {
                //Set headerLine 
                this.headerLine = textReader.ReadLine().Split(
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

                    Student current = this.StudentParser(data);
                    if (current != null)
                    {
                        list.Add(current);
                    }
                }
            }

            return list;
        }

        public virtual Student StudentParser(string[] textData)
        {
            // Don't touch it's magic
            if (textData.Length < 4)
            {
                return null;
            }
            else
            {
                var student = new Student()
                {
                    FirstName = textData[1],
                    LastName = textData[2],
                    Email = textData[3],
                    FacultyNumber = nextStudentId++,
                    Age = Random.Next(MinAge, MaxAge),
                    GroupNumber = Random.Next(MinGroup, MaxGroup),
                    Phone = this.GeneratePhone(),
                    MarksList = this.GenerateMarks()
                };

                return student;
            }
        }

        private IList<int> GenerateMarks()
        {
            var marks = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                int mark = Random.Next(2, 7);
                marks.Add(mark);
            }

            return marks;
        }

        private string GeneratePhone()
        {
            var phone = new int[7];

            for (int i = 0; i < phone.Length; i++)
            {
                phone[i] = Random.Next(0, 10);
            }

            return "+359" + string.Join("", phone);
        }
    }
}
