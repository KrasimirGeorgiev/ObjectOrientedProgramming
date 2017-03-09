namespace Telerik.Homeworks.OOP.Principles.SchoolClasses
{
    using System.Collections.Generic;

    public class Student : Person
    {
        public Student(string fname, string lname)
            : base(fname, lname)
        {
            this.ShoolClasses = new HashSet<ShoolClass>();
        }

        public Comment Comment { get; set; }

        public ICollection<ShoolClass> ShoolClasses { get; }

        public uint ClassNumber { get; private set; }

        public void AssignClassNumber(uint number)
        {
            this.ClassNumber = number;
        }
    }
}
