namespace Telerik.Homeworks.OOP.Principles.Banks.Accounts.Balances
{
    using System;
    using Interfaces;

    [Serializable]
    public class Balance : IBalance
    {
        private readonly TransactionHistory transactionHistory;

        private decimal funds;

        public Balance()
        {
            this.transactionHistory = new TransactionHistory();
        }

        public Balance(decimal initialFunds)
            : this()
        {
            this.Funds = initialFunds;
        }

        public decimal Funds
        {
            get
            {
                return this.funds;
            }

            set
            {
                decimal amount = value - this.funds;

                this.funds = value;

                this.transactionHistory.Add(amount);
            }
        }
    }
}