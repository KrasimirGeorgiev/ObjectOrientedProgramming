namespace Telerik.Homeworks.OOP.Principles.StudentsAndWorkers
{
    using System;

    public class Worker : Human
    {
        public const int MaxHoursPerDay = 8;
        public const int WorkDaysPerWeek = 5;
        public const decimal MinimalSalary = 400;
        public const decimal MaximalSalary = 40000;

        private decimal weekSalary;
        private int workHoursPerDay;

        public Worker(string fitstName, string lastName, decimal weekSalary, int hours)
            : base(fitstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = hours;
        }

        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }

            set
            {
                if (value < MinimalSalary)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "This man's boss is an animal");
                }

                this.weekSalary = value;
            }
        }

        public int WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }

            set
            {
                if (value > MaxHoursPerDay)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Give this man a break!");
                }

                this.workHoursPerDay = value;
            }
        }

        public decimal MoneyPerHour()
        {
            decimal moneyPerDay = this.weekSalary / WorkDaysPerWeek;
            decimal moneyPerHour = moneyPerDay / this.workHoursPerDay;

            return moneyPerHour;
        }

        public override string ToString()
        {
            return string.Format(base.ToString() + "\r\nMoney Per Hour: '{0:F}'", this.MoneyPerHour());
        }
    }
}
