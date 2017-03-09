namespace Telerik.Homeworks.OOP.Principles
{
    using System;
    using System.Threading;
    using ConsoleMio.ConsoleEnhancements;
    using Shapes;
    using static System.ConsoleColor;

    public class ShapesTests
    {
        private const ConsoleColor Info = DarkRed;
        private const ConsoleColor Result = DarkBlue;
        private const ConsoleColor Warning = DarkCyan;

        private static readonly ConsoleMio ConsoleMio = new ConsoleMio();

        private static void Main()
        {
            ConsoleMio.PrintHeading("Homework: OOP Principles - Part 2 - Shapes");

            while (true)
            {
                ConsoleMio.Setup();
                Prompt();
            }
        }

        private static void Prompt()
        {
            const string triangle = "Create a Triangle";
            const string rect = "Create a Rectangle";
            const string square = "Create a Square";
            const string quit = "Quit";

            var menu = ConsoleMio.CreatePromptMenu<string>(
               "What would you like to do?",
                new[] { triangle, rect, square, quit });

            var choice = menu.Show(Black, Warning);
            ConsoleMio.WriteLine();

            double[] args;
            switch (choice)
            {
                case triangle:
                    args = ReadInput("Enter hypotenuse and side lengths: ", 2);
                    CreateTriangle(args[0], args[1]);
                    break;
                case rect:
                    args = ReadInput("Enter A and B sides: ", 2);
                    CreateRectangle(args[0], args[1]);
                    break;
                case square:
                    args = ReadInput("Enter the square side: ", 1);
                    CreateSquare(args[0]);
                    break;
                case quit:
                    ConsoleMio.WriteLine("Byem bye...", DarkRed);
                    Thread.Sleep(1000);
                    Environment.Exit(0);
                    break;
                default:
                    throw new ApplicationException("Invalid menu choice");
            }
        }

        private static double[] ReadInput(string prompt, int parametersCount)
        {
            string subject = parametersCount == 1
                ? "number"
                : $"{parametersCount} numbers on the same line separated by space";

            double[] args = ConsoleMio.ReadInput(
                    prompt, new[] { " " }, double.Parse, parametersCount, Info, Result, Warning);

            return args;
        }

        private static void CreateSquare(double side)
        {
            ConsoleMio
                .Write("Creating a square with side of: ", Info)
                .WriteLine(side, Result);

            var square = new Square(side);

            PrintResult(square);
        }

        private static void CreateRectangle(double width, double height)
        {
            ConsoleMio
                .Write("Creating a rectangle with sides: ", Info)
                .FormatLine("{0:F} {1:F}", Result, width, height);

            var rect = new Rectangle(width, height);

            PrintResult(rect);
        }

        private static void CreateTriangle(double hypotenuse, double side)
        {
            ConsoleMio
               .Write("Creating a triangle with hypotenuse and side: ", Info)
               .FormatLine("{0:F} {1:F}", Result, hypotenuse, side);

            var triangle = new Rectangle(hypotenuse, side);

            PrintResult(triangle);
        }

        private static void PrintResult(Shape shape)
        {
            ConsoleMio
                .Write("Surface = ", Info)
                .FormatLine("{0:F}", Result, shape.CalculateSurface());

            ConsoleMio.PromptToContinue(Warning);
        }
    }
}
