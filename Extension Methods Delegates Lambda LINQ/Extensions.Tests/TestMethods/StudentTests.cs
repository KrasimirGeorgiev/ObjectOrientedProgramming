namespace Extensions.Tests.TestMethods
{
    using System;
    using System.Collections.Generic;
    using ConsoleMio.ConsoleEnhancements;
    using Models;
    using Models.Generators;
    using static Common;

    public class StudentTests
    {
        public StudentTests(ConsoleMio consoleMio, SimpleGenerator studentsGenerator)
        {
            this.ConsoleMio = consoleMio;
            this.StudentsGenerator = studentsGenerator;
            this.TestStudents = this.StudentsGenerator.Generate(7);
        }

        public ConsoleMio ConsoleMio { get; }

        public SimpleGenerator StudentsGenerator { get; }

        public IEnumerable<Student> TestStudents { get; private set; }

        public void FirstBeforeLast()
        {
            this.ConsoleMio
                .WriteLine("Testing IEnumerable<Student>.GetFristBeforeLast()", Info)
                .WriteLine();

            var result = this.TestStudents.GetFirstBeforeLast();
            this.PrintResult(result);
        }

        public void AgeRange()
        {
            this.ConsoleMio
                .WriteLine("Testing IEnumerable<Student>.GetStudentsOfAge(18, 24)", Info)
                .WriteLine();

            var result = this.TestStudents.GetStudentsOfAge(18, 24);
            this.PrintResult(result);
        }

        public void OrderBy()
        {
            this.ConsoleMio
                .WriteLine("Testing IEnumerable<Student>.OrderByFullName()", Info)
                .WriteLine();

            var result = this.TestStudents.OrderByFullName();
            this.PrintResult(result);
        }

        public void StudentsOfGroup()
        {
            this.ConsoleMio
                .WriteLine("Testing IEnumerable<Student>.StudentsOfGroup(2)", Info)
                .WriteLine();

            var result = this.TestStudents.StudentsOfGroup(2);
            this.PrintResult(result);
        }

        public void StudentsWihEmail()
        {
            this.ConsoleMio
                .WriteLine("Testing IEnumerable<Student>.StudentsOfDomain(yahoo.com)", Info)
                .WriteLine();

            var result = this.TestStudents.StudentsOfDomain("yahoo.com");
            this.PrintResult(result);
        }

        public void StudentsWithPhone()
        {
            this.ConsoleMio
                .WriteLine("Testing IEnumerable<Student>.StudentsWithPhoneCode(+3592)", Info)
                .WriteLine();

            var result = this.TestStudents.StudentsWithPhoneCode("+3592");
            this.PrintResult(result);
        }

        public void StudentsByGroup()
        {
            this.ConsoleMio
                .WriteLine("Testing IEnumerable<Student>.GroupStudentsByGroupNumber()", Info)
                .WriteLine();

            var result = this.TestStudents.GroupStudentsByGroupNumber();

            this.ConsoleMio.WriteLine("Original Collection: ", Info);
            this.PrintStudentsCollection(this.TestStudents);

            foreach (var group in result)
            {
                this.ConsoleMio.FormatLine("Group #{0}: ", Info, group.Key);
                this.PrintStudentsCollection(group);
            }
        }

        private void PrintResult(IEnumerable<Student> result)
        {
            this.ConsoleMio.WriteLine("Original Collection: ", Info);
            this.PrintStudentsCollection(this.TestStudents);

            this.ConsoleMio
                .Write(new string('-', Console.WindowWidth), MenuBg)
                .WriteLine("Filtered collection: ", Info)
                .Write(new string('-', Console.WindowWidth), MenuBg);

            this.PrintStudentsCollection(result);
        }

        private void PrintStudentsCollection(IEnumerable<Student> collection)
        {
            this.ConsoleMio.WriteLine("Students: ", Info);

            bool odd = true;
            foreach (var student in collection)
            {
                this.ConsoleMio.WriteLine(student, odd ? Result : Info);

                odd = !odd;
            }

            this.ConsoleMio.WriteLine();
        }
    }
}