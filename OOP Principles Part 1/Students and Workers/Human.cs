namespace Telerik.Homeworks.OOP.Principles.StudentsAndWorkers
{
    using Validation;

    public abstract class Human
    {
        private string firstName;

        private string lastName;

        protected Human(string fitstName, string lastName)
        {
            this.FirstName = fitstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                string name = Validator.ValidateName(value);

                this.firstName = name;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                string name = Validator.ValidateName(value);

                this.lastName = name;
            }
        }

        public override string ToString()
        {
            return $"First Name: '{this.FirstName}' \r\nLastName: '{this.LastName}'";
        }
    }
}
