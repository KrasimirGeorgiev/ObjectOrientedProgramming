namespace Telerik.Homeworks.OOP.Principles.Banks.Customers.Interfaces
{
    public interface ICustomer
    {
        string FirstName { get; }

        string LastName { get; }

        string ToString();

        decimal CalculateLoanInterests(int months, decimal interestRate);

        decimal CalculateMortageInterests(int months, decimal interestRate);
    }
}
