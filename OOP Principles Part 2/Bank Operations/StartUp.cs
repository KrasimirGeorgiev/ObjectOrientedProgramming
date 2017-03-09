namespace Telerik.Homeworks.OOP.Principles
{
    using System;
    using System.IO;
    using System.Threading;
    using Banks;
    using ConsoleMio.ConsoleEnhancements;
    using static Colors;

    public class StartUp
    {
        public const string DataFilePath = "Database";

        private static readonly ConsoleMio ConsoleMio = new ConsoleMio();
        private static Bank bestBank;

        private static CommandInterface commandInterface;

        private static void Main()
        {
            ConsoleMio.PrintHeading("Homework: OOP Principles - Part 2 - Bank Accounts");

            bestBank = File.Exists(DataFilePath)
                ? BinaryHandler.ReadFromBinaryFile<Bank>(DataFilePath)
                : new Bank("Best Bank", 3.5m);

            commandInterface = new CommandInterface(ConsoleMio, bestBank, OnQuit);

            Loop();
        }

        private static void Loop()
        {
            while (true)
            {
                string[] actions =
                {
                    "Register a customer",
                    "Review existing customers",
                    "Quit"
                };

                var menu = ConsoleMio.CreatePromptMenu(
                    "What would you like to do?", actions);

                var choice = menu.Show(Black, Warning);

                if (choice == actions[0])
                {
                    commandInterface.RegisterCustomer();
                }
                else if (choice == actions[1])
                {
                    commandInterface.ReviewCustomers();
                }
                else if (choice == actions[2])
                {
                    OnQuit();
                }
                else
                {
                    throw new NotImplementedException("This action isn't implemented yet");
                }

                ConsoleMio.WriteLine();
            }
        }

        private static void OnQuit()
        {
            ConsoleMio
                .WriteLine("Saving existing data...", Warning)
                .WriteLine("Bye, bye...", Warning);
            BinaryHandler.WriteToBinaryFile(DataFilePath, bestBank);
            Thread.Sleep(1000);
            Environment.Exit(0);
        }
    }
}
