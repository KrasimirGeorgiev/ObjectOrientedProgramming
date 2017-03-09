namespace Telerik.Homeworks.OOP.Principles.Banks.Accounts
{
    using System;
    using Balances.Interfaces;
    using Customers.Interfaces;

    [Serializable]
    public class Deposit : Account
    {
        public Deposit(ICustomer customer, IBalance initialBalance, decimal interestRate)
            : base(customer, initialBalance, interestRate)
        {
        }

        public override decimal GetInterestAmountFor(int months)
        {
            if (this.Balance.Funds < 1000)
            {
                return 0;
            }
            else
            {
                return months * this.InterestRate;
            }
        }

        public override void MakeDeposit(decimal amount)
        {
            base.MakeDeposit(amount);

            this.Balance.Funds += amount;
        }

        public override void MakeWithdraw(decimal amount)
        {
            base.MakeWithdraw(amount);

            if (amount > this.Balance.Funds)
            {
                throw new ApplicationException(
                    "Trying to withdraw more money than the existing balance's funds");
            }

            this.Balance.Funds -= amount;
        }
    }
}
