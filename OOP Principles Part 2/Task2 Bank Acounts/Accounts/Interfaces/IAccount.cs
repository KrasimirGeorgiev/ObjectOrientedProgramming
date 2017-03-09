namespace Telerik.Homeworks.OOP.Principles.Banks.Accounts.Interfaces
{
    using Balances.Interfaces;
    using Customers.Interfaces;

    public interface IAccount
    {
        ICustomer Customer { get; }

        decimal InterestRate { get; }

        IBalance Balance { get; }

        string ToString();

        void MakeDeposit(decimal amount);

        void MakeWithdraw(decimal amount);

        decimal GetInterestAmountFor(int months);
    }
}
