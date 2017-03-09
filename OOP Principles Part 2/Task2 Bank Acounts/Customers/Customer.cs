namespace Telerik.Homeworks.OOP.Principles.Banks.Customers
{
    using System;
    using Interfaces;

    [Serializable]
    public abstract class Customer : ICustomer
    {
        protected Customer(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; protected set; }

        public string LastName { get; protected set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }

        public abstract decimal CalculateLoanInterests(int months, decimal interestRate);

        public abstract decimal CalculateMortageInterests(int months, decimal interestRate);

        protected decimal CalculateInterests(
            int months, decimal interestRate, int noInterestMonths)
        {
            if (months <= noInterestMonths)
            {
                return 0;
            }

            decimal interests = (months - noInterestMonths) * interestRate;

            return interests;
        }

        protected decimal CalculateInterests(int months, decimal interestRate)
        {
            return this.CalculateInterests(months, interestRate, 0);
        }
    }
}
