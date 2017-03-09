namespace Telerik.Homeworks.OOP.Principles.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ConsoleMio.ConsoleEnhancements;

    internal class AnimalProgram
    {
        private const ConsoleColor Info = ConsoleColor.Blue;
        private const ConsoleColor Result = ConsoleColor.DarkRed;
        private static readonly string Dash = new string('-', 50);

        private static readonly ConsoleMio ConsoleMio = new ConsoleMio();

        private static void Main()
        {
            ConsoleMio.PrintHeading("OOP Principles - Part 1 - Animals");

            var animals = GenerateAnimals();

            PrintAnimals(animals);

            var averageAges = GetAverageAges(animals);

            ConsoleMio.PromptToContinue(Info);
            ConsoleMio.WriteLine("Average Ages:", Info)
                      .WriteLine(Dash, Info);

            foreach (var key in averageAges.Keys)
            {
                ConsoleMio.Write(key, Result)
                          .Write(" average age: ", Info)
                          .FormatLine("{0:F}", Result, averageAges[key]);
            }

            ConsoleMio.WriteLine(Dash, Info)
                      .WriteLine();
        }

        private static IList<Animal> GenerateAnimals()
        {
            var animals = new List<Animal>()
            {
                new Dog("Pesho", Gender.Male, 12),
                new Kitten("Petia", 11),
                new Tomcat("Petko", 5),
                new Frog("Petra", Gender.Female, 3),
                new Dog("Penio", Gender.Male, 23),
                new Kitten("Paca", 1),
                new Tomcat("Paco", 6),
                new Frog("Panko", Gender.Male, 5),
                new Dog("Penka", Gender.Female, 10),
                new Kitten("Peruna", 4),
                new Tomcat("Pencho", 6),
                new Frog("Petar", Gender.Male, 2)
            };

            return animals;
        }

        private static IDictionary<string, double> GetAverageAges(IEnumerable<Animal> animals)
        {
            var results = animals
                .GroupBy(a => a.GetType().Name)
                .ToDictionary(
                    grouping => grouping.Key,
                    grouping => grouping.Average(animal => animal.Age));

            return results;
        }

        private static void PrintAnimals(IEnumerable<Animal> animals)
        {
            ConsoleMio.WriteLine("Animals: ", Info)
                      .WriteLine();

            foreach (var animal in animals)
            {
                ConsoleMio.WriteLine(animal.Speak(), Result)
                          .WriteLine(Dash, Info);
            }

            ConsoleMio.WriteLine();
        }
    }
}
