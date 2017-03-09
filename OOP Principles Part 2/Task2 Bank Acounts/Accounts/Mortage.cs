namespace Telerik.Homeworks.OOP.Principles.Banks.Accounts
{
    using System;
    using Balances.Interfaces;
    using Customers.Interfaces;

    [Serializable]
    public class Mortage : Account
    {
        public Mortage(ICustomer customer, IBalance initialBalance, decimal interestRate)
            : base(customer, initialBalance, interestRate)
        {
        }

        public override decimal GetInterestAmountFor(int months)
        {
            return this.Customer.CalculateMortageInterests(months, this.InterestRate);
        }

        public override void MakeDeposit(decimal amount)
        {
            this.Balance.Funds += amount;
        }
    }
}