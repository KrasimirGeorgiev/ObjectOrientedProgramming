namespace Telerik.Homeworks.OOP.Principles.Banks.Accounts.Balances
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    [Serializable]
    public class TransactionHistory : ITransactionHistory
    {
        private readonly Dictionary<DateTime, decimal> history;

        public TransactionHistory()
        {
            this.history = new Dictionary<DateTime, decimal>();
        }

        public int Length => this.history.Count;

        public decimal this[DateTime date]
        {
            get
            {
                if (this.history.ContainsKey(date))
                {
                    return this.history[date];
                }
                else
                {
                    return 0;
                }
            }
        }

        public void Add(decimal amount, DateTime date)
        {
            if (this.history.ContainsKey(date))
            {
                this.history[date] += amount;
            }
            else
            {
                this.history[date] = amount;
            }
        }

        public void Add(decimal amount)
        {
            this.Add(amount, DateTime.Now);
        }

        public List<DateTime> GetDates()
        {
            return this.history
                    .Keys
                    .ToList();
        }

        public IEnumerator<decimal> GetEnumerator()
        {
            return this.history.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.history.Values.GetEnumerator();
        }
    }
}
