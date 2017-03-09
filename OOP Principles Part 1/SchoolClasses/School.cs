namespace Telerik.Homeworks.OOP.Principles.SchoolClasses
{
    using System.Collections.Generic;
    using Validation;

    public class School
    {
        private string name;

        public School(string name)
        {
            this.Name = name;
            this.Classes = new List<ShoolClass>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = Validator.ValidateName(value);
            }
        }

        public IList<ShoolClass> Classes { get; private set; }
    }
}
