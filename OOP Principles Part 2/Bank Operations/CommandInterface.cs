namespace Telerik.Homeworks.OOP.Principles
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Banks;
    using Banks.Accounts;
    using Banks.Accounts.Interfaces;
    using Banks.Customers;
    using Banks.Customers.Interfaces;
    using ConsoleMio.ConsoleEnhancements;
    using static Colors;

    public class CommandInterface
    {
        private const string Back = "Back";
        private static readonly string[] Separators = new[] { " ", "," };
        private readonly ConsoleMio console;
        private readonly Bank bank;

        public CommandInterface(
            ConsoleMio consoleHandler, Bank bank, Action onQuitCallback)
        {
            this.console = consoleHandler;
            this.bank = bank;
            this.OnQuit = onQuitCallback;
        }

        public Action OnQuit { get; set; }

        public void RegisterCustomer()
        {
            var accountType = this.Prompt(
                "What kind of customer would you like to register",
                nameof(Company),
                nameof(Individual));

            string[] names;
            ICustomer customer;

            if (accountType == nameof(Company))
            {
                names = this.ReadNames("Enter company's owner names: ");
                customer = new Company(names[0], names[1]);
            }
            else
            {
                names = this.ReadNames("Enter the individual's names: ");
                customer = new Individual(names[0], names[1]);
            }

            this.bank.RegisterCustomer(customer);
            this.console
                .Write(customer, Result)
                .WriteLine(" registered successfully", Info);
        }

        public void ReviewCustomers()
        {
            if (this.bank.Clients.Count == 0)
            {
                this.console.WriteLine(
                    "There are no registered customers right now",
                    Info);

                return;
            }

            ICustomer customer = this.Prompt(
                "Select a customer for additional actions", this.bank.Clients.ToArray());

            this.DisplayCustomerOptions(customer);
        }

        private static string Capitalize(string str)
        {
            return char.ToUpper(str[0]) + str.Substring(1);
        }

        private void DisplayCustomerOptions(ICustomer customer)
        {
            var accounts = this.bank.GetAccountsOf(customer);

            string accountType = this.Prompt(
                "Select an account", nameof(Deposit), nameof(Loan), nameof(Mortage), Back);

            if (accountType == Back)
            {
                this.ReviewCustomers();
            }

            IAccount account = accounts.FirstOrDefault(a => a.GetType().Name == accountType);
            if (account == null)
            {
                account = this.CreateAnAccount(customer, accountType);
                if (account == null)
                {
                    this.DisplayCustomerOptions(customer);
                }
            }

            this.console.WriteLine(account, Result);

            string choice = this.Prompt(
                "Continue with: ",
                $"Back to {customer.LastName}'s accounts",
                "Return to start menu",
                "Quit");

            if (choice.StartsWith("Back"))
            {
                this.DisplayCustomerOptions(customer);
            }
            else if (choice.StartsWith("Quit"))
            {
                this.OnQuit();
            }
        }

        private IAccount CreateAnAccount(ICustomer customer, string type)
        {
            this.console
                    .Write($"{customer.FirstName} {customer.LastName} doesn't have a ", Info)
                    .Write(type, Result)
                    .WriteLine(" account", Info);

            bool doCreate = this.Prompt(
                "Would you like to create one: ", "Yes", "No") == "Yes";

            if (doCreate)
            {
                decimal amount = this.ReadAmount("Enter amount: ");
                MethodInfo info = typeof(Bank).GetMethod(type);

                IAccount account = info.Invoke(
                    this.bank, new object[] { customer, amount }) as IAccount;

                return account;
            }
            else
            {
                return null;
            }
        }

        private string[] ReadNames(string message)
        {
            string[] names = this.console.ReadInput(
                    message, Separators, Capitalize, 2, Info, Result, Warning);

            return names;
        }

        private decimal ReadAmount(string message)
        {
            decimal input = this.console.ReadInput(
                message, Separators, decimal.Parse, 1, Info, Result, Warning)[0];

            return input;
        }

        private T Prompt<T>(string message, params T[] choices)
        {
            var menu = this.console.CreatePromptMenu(message, choices);
            return menu.Show(Black, Warning);
        }
    }
}
