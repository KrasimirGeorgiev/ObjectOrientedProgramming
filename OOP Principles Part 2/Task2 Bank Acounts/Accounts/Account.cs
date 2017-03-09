namespace Telerik.Homeworks.OOP.Principles.Banks.Accounts
{
    using System;
    using Balances.Interfaces;
    using Customers.Interfaces;
    using Interfaces;

    [Serializable]
    public abstract class Account : IAccount
    {
        protected Account(ICustomer customer, IBalance initialBalance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = initialBalance;
            this.InterestRate = interestRate;
        }

        public ICustomer Customer { get; protected set; }

        public decimal InterestRate { get; protected set; }

        public IBalance Balance { get; protected set; }

        public override string ToString()
        {
            return
                $"Holder: {this.Customer.FirstName + ' ' + this.Customer.LastName}\n" +
                $"Interest Rate: {this.InterestRate}\n" +
                $"Ballance: {this.Balance.Funds:F}\n" +
                $"Interest for 12 months: {this.GetInterestAmountFor(12)}";
        }

        public virtual void MakeDeposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ApplicationException("This method only works with positive values above zero");
            }
        }

        public virtual void MakeWithdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ApplicationException("This method only works with positive values above zero");
            }
        }

        public abstract decimal GetInterestAmountFor(int months);
    }
}
