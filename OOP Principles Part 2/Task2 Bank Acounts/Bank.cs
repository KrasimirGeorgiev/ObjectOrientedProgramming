namespace Telerik.Homeworks.OOP.Principles.Banks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Accounts;
    using Accounts.Balances;
    using Accounts.Interfaces;
    using Customers.Interfaces;

    [Serializable]
    public class Bank
    {
        private const string DepositAccount = nameof(DepositAccount);
        private const string MortageAccount = nameof(MortageAccount);
        private const string LoanAccount = nameof(LoanAccount);

        private readonly IDictionary<string, ISet<ICustomer>> customersByAccount;
        private readonly IDictionary<ICustomer, IList<IAccount>> accountsByCustomer;

        public Bank(string name, decimal interestRate)
        {
            this.Name = name;
            this.InterestRate = interestRate;

            this.customersByAccount = new Dictionary<string, ISet<ICustomer>>
            {
                [DepositAccount] = new HashSet<ICustomer>(),
                [MortageAccount] = new HashSet<ICustomer>(),
                [LoanAccount] = new HashSet<ICustomer>()
            };

            this.accountsByCustomer = new Dictionary<ICustomer, IList<IAccount>>();
        }

        public string Name { get; set; }

        public decimal InterestRate { get; }

        public ICollection<ICustomer> Clients => this.accountsByCustomer.Keys;

        public IEnumerable<IAccount> Accounts => this.accountsByCustomer
                                                     .Values.SelectMany(a => a);

        public IAccount Deposit(ICustomer customer, decimal initialFunds)
        {
            var customerDeposit = new Deposit(
                customer, new Balance(initialFunds), this.InterestRate);

            if (!this.accountsByCustomer.ContainsKey(customer))
            {
                this.accountsByCustomer[customer] = new List<IAccount>();
            }

            this.accountsByCustomer[customer].Add(customerDeposit);
            this.customersByAccount[DepositAccount].Add(customer);

            return customerDeposit;
        }

        public IAccount Loan(ICustomer customer, decimal loanAmount)
        {
            var customerLoan = new Loan(
                customer, new Balance(-loanAmount), this.InterestRate);

            if (!this.accountsByCustomer.ContainsKey(customer))
            {
                this.accountsByCustomer[customer] = new List<IAccount>();
            }

            this.accountsByCustomer[customer].Add(customerLoan);
            this.customersByAccount[LoanAccount].Add(customer);

            return customerLoan;
        }

        public IAccount Mortage(ICustomer customer, decimal mortageAmount)
        {
            var customerMortage = new Mortage(
                customer, new Balance(-mortageAmount), this.InterestRate);

            if (!this.accountsByCustomer.ContainsKey(customer))
            {
                this.accountsByCustomer[customer] = new List<IAccount>();
            }

            this.accountsByCustomer[customer].Add(customerMortage);
            this.customersByAccount[MortageAccount].Add(customer);

            return customerMortage;
        }

        public void RegisterCustomer(ICustomer customer)
        {
            if (!this.accountsByCustomer.ContainsKey(customer))
            {
                this.accountsByCustomer[customer] = new List<IAccount>();
            }
        }

        public ICollection<IAccount> GetAccountsOf(ICustomer customer)
        {
            return this.accountsByCustomer[customer];
        }

        public void RemoveAccount(IAccount account)
        {
            var customer = account.Customer;
            string type = account.GetType().Name;
            this.accountsByCustomer[customer].Remove(account);
            this.customersByAccount[type].Remove(customer);
        }
    }
}
