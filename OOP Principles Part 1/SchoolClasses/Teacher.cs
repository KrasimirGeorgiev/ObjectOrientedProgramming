namespace Telerik.Homeworks.OOP.Principles.SchoolClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Teacher : Person
    {
        public Teacher(string fname, string lname)
            : base(fname, lname)
        {
            this.Disciplines = new HashSet<Discipline>();
        }

        public Teacher(string fname, string lname, IEnumerable<Discipline> disciplines)
            : base(fname, lname)
        {
            this.Disciplines = new HashSet<Discipline>(disciplines);
        }

        public ICollection<Discipline> Disciplines { get; }

        public Comment Comment { get; set; }

        public void AddDisciplines(Discipline subject)
        {
            this.Disciplines.Add(subject);
        }

        public Discipline RemoveDiscipline(string name)
        {
            var discipline = this.Disciplines.FirstOrDefault(d => d.Name.Equals(name, StringComparison.Ordinal));
            this.RemoveDiscipline(discipline);

            return discipline;
        }

        public void RemoveDiscipline(Discipline subject)
        {
            bool success = this.Disciplines.Remove(subject);

            if (!success)
            {
                throw new ArgumentException("The discipline could not be found in this teacher's Disciplines");
            }
        }
    }
}
