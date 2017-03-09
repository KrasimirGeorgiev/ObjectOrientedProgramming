namespace Telerik.Homeworks.OOP.Principles.Banks.Customers
{
    using System;

    [Serializable]
    public class Company : Customer
    {
        public const decimal MortageInterestDecrease = 0.5m;

        public const int MortageInterestDecreaseDuration = 12;

        public const int NoLoanInterestMonths = 2;

        public Company(string firstName, string lastName)
            : base(firstName, lastName)
        {
        }

        public override decimal CalculateLoanInterests(int months, decimal interestRate)
        {
            return this.CalculateInterests(months, interestRate, NoLoanInterestMonths);
        }

        public override decimal CalculateMortageInterests(int months, decimal interestRate)
        {
            decimal reducedInterest = interestRate * MortageInterestDecrease;

            if (months <= MortageInterestDecreaseDuration)
            {
                return this.CalculateInterests(months, reducedInterest);
            }
            else
            {
                decimal interests = this.CalculateInterests(MortageInterestDecreaseDuration, reducedInterest, 0);
                int remainingMonths = months - MortageInterestDecreaseDuration;

                interests += this.CalculateInterests(remainingMonths, interestRate);

                return interests;
            }
        }

        public override string ToString()
        {
            return $"Company Owner: {base.ToString()}";
        }
    }
}
