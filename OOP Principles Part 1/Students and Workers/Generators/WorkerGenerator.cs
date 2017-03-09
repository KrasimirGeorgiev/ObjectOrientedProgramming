namespace Telerik.Homeworks.OOP.Principles.StudentsAndWorkers.Generators
{
    public class WorkerGenerator : SimpleGenerator<Worker>
    {
        protected override Worker GenerateType(string[] data)
        {
            var worker = new Worker(
                data[1],
                data[2],
                this.GenerateSalary(),
                this.GenerateWorkHours());

            return worker;
        }

        private decimal GenerateSalary()
        {
            decimal salary = ((decimal)Random.NextDouble() *
                (Worker.MaximalSalary - Worker.MinimalSalary)) +
                                     Worker.MinimalSalary;

            return salary;
        }

        private int GenerateWorkHours()
        {
            int hours = Random.Next(1, Worker.MaxHoursPerDay + 1);
            return hours;
        }
    }
}
