namespace Telerik.Homeworks.OOP.Principles.Banks.Accounts.Balances.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface ITransactionHistory : IEnumerable<decimal>
    {
        int Length { get; }

        decimal this[DateTime date] { get; }

        void Add(decimal amount, DateTime date);

        void Add(decimal amount);

        List<DateTime> GetDates();
    }
}
