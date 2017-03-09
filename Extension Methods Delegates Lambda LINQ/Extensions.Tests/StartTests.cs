namespace Extensions.Tests
{
    using System;
    using System.Diagnostics;
    using System.Reflection;
    using System.Text;
    using System.Threading;
    using ConsoleMio.ConsoleEnhancements;
    using Models;
    using Models.Generators;
    using TestMethods;
    using static Common;

    public class StartTests
    {
        private static readonly ConsoleMio ConsoleMio = new ConsoleMio();
        private static readonly SimpleGenerator StudentsGenerator = new SimpleGenerator();

        private static readonly EnumerableTests EnumerableTests = new EnumerableTests(ConsoleMio);
        private static readonly StudentTests StudentTests = new StudentTests(ConsoleMio, StudentsGenerator);
        private static int seconds = 0;
        private static HomeworkTimer timer;

        private static void Main()
        {
            ConsoleMio.PrintHeading("Extension Methods Tests");

            ConsoleMio.WriteLine("What would you like to test: ", Info);
            var menu = ConsoleMio.CreateMenu(new[]
            {
                nameof(Enumerable_Tests),
                nameof(Student_Tests),
                nameof(StringBuilder_Test),
                nameof(StartStopTimer),
                nameof(Quit)
            });

            while (true)
            {
                Execute(menu, typeof(StartTests));
            }
        }

        public static void Student_Tests()
        {
            ConsoleMio.WriteLine("Pick a subject: ", Info);
            var menu = ConsoleMio.CreateMenu(new[]
            {
                nameof(StudentTests.FirstBeforeLast),
                nameof(StudentTests.AgeRange),
                nameof(StudentTests.OrderBy),
                nameof(StudentTests.StudentsOfGroup),
                nameof(StudentTests.StudentsWihEmail),
                nameof(StudentTests.StudentsWithPhone),
                nameof(StudentTests.StudentsByGroup)
            });

            Execute(menu, typeof(StudentTests), StudentTests);
            Reset();
        }

        public static void Enumerable_Tests()
        {
            ConsoleMio.WriteLine("Pick a subject: ", Info);
            var menu = ConsoleMio.CreateMenu(new[]
            {
                nameof(StringBuilder_Test),
                nameof(EnumerableTests.EnumerableMax),
                nameof(EnumerableTests.EnumerableMin),
                nameof(EnumerableTests.EnumerableSum),
                nameof(EnumerableTests.EnumerableProduct),
                nameof(EnumerableTests.EnumerableAverage),
                nameof(EnumerableTests.EnumerableDivisibleBy)
            });

            Execute(menu, typeof(EnumerableTests), EnumerableTests);
            Reset();
        }

        public static void StringBuilder_Test()
        {
            const string testPhrase = "Super string builder test";

            ConsoleMio
                .WriteLine("Testing String Builder", Info)
                .WriteLine();

            var sb = new StringBuilder();
            sb.AppendLine(testPhrase);

            int index = testPhrase.IndexOf("string", StringComparison.Ordinal);
            int length = "string builder".Length;

            var newSb = sb.Substring(index, length);

            Debug.Assert(newSb.ToString() == "string builder");

            ConsoleMio.WriteLine("Test passed...", Result);
            Reset();
        }

        public static void StartStopTimer()
        {
            if (timer == null)
            {
                timer = new HomeworkTimer()
                    // SubscribeOnce
                    .Subscribe(OnOneSecond)
                    .Start();
            }
            else if (timer.IsRunning)
            {
                timer.Stop();
            }
            else
            {
                timer.Start();
            }
        }

        public static void Quit()
        {
            ConsoleMio.WriteLine("Bye bye", Info);
            Thread.Sleep(1000);

            Environment.Exit(0);
        }

        private static void Execute(ConsoleMenu<string> menu, Type type, object instance = null)
        {
            string selected = menu.Show(MenuBg, Menu);

            //Get the method information using the method info class
            MethodInfo mi = type.GetMethod(selected);
            mi.Invoke(instance, null);
        }

        private static void Reset()
        {
            ConsoleMio.WriteLine();
            ConsoleMio.PromptToContinue(Info);
            Console.Clear();

            ConsoleMio.PrintHeading("Extension Methods Tests");
            ConsoleMio.WriteLine("What would you like to test: ", Info);
        }

        private static void OnOneSecond()
        {
            var oldLeft = Console.CursorLeft;
            var oldTop = Console.CursorTop;

            Console.SetCursorPosition(0, 0);
            ConsoleMio.FormatLine("Elapsed: {0} seconds", Info, ++seconds);
            Console.SetCursorPosition(oldLeft, oldTop);
        }
    }
}
