namespace Telerik.Homeworks.OOP.Principles.StudentsAndWorkers
{
    using Validation;

    public class Student : Human
    {
        public const int MinGrade = 1;
        public const int MaxGrade = 10;

        private int grade;

        public Student(string fitstName, string lastName)
            : base(fitstName, lastName)
        {
        }

        public Student(string fitstName, string lastName, int grade)
            : this(fitstName, lastName)
        {
            this.Grade = grade;
        }

        public int Grade
        {
            get
            {
                return this.grade;
            }

            set
            {
                this.grade = Validator.ValidateNumber(value, MinGrade, MaxGrade);
            }
        }

        public override string ToString()
        {
            return string.Format(base.ToString() + "\r\nGrade: {0}", this.Grade);
        }
    }
}
