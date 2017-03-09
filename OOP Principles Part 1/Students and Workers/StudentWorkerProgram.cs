namespace Telerik.Homeworks.OOP.Principles.StudentsAndWorkers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ConsoleMio.ConsoleEnhancements;
    using StudentsAndWorkers.Generators;

    internal class StudentWorkerProgram
    {
        private const ConsoleColor Info = ConsoleColor.Blue;
        private const ConsoleColor Result = ConsoleColor.DarkRed;

        private static readonly ConsoleMio ConsoleMio = new ConsoleMio();
        private static readonly StudentsGenerator StudentsGenerator = new StudentsGenerator();
        private static readonly WorkerGenerator WorkerGenerator = new WorkerGenerator();

        private static void Main(string[] args)
        {
            ConsoleMio.PrintHeading("OOP Principles - Part 1 - Students And Workers");

            var students = StudentsGenerator.Generate(10)
                .OrderBy(s => s.Grade);

            ConsoleMio.WriteLine("Students by grade: \n", Info);
            PrintPeople(students);

            var workers = WorkerGenerator.Generate(10, 11)
                .OrderByDescending(w => w.MoneyPerHour());

            ConsoleMio.WriteLine("Workerks by income: \n", Info);
            PrintPeople(workers);

            var people = new List<Human>(students);
            people.AddRange(workers);

            people = people
                .OrderBy(p => p.FirstName)
                .ThenBy(p => p.LastName)
                .ToList();

            ConsoleMio.WriteLine("People by name: \n", Info);
            PrintPeople(people);
        }

        private static void PrintPeople(IEnumerable<Human> people)
        {
            bool odd = true;

            foreach (var human in people)
            {
                ConsoleMio
                    .WriteLine(human, odd ? Result : Info);

                odd = !odd;
            }

            ConsoleMio.WriteLine();
            ConsoleMio.PromptToContinue(Info);
        }
    }
}
