namespace Telerik.Homeworks.OOP.Principles.SchoolClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ShoolClass
    {
        private readonly Dictionary<uint, Student> studentsByNumber;

        private uint nextStudentNumber = 1;

        public ShoolClass()
        {
            this.studentsByNumber = new Dictionary<uint, Student>();
            this.Teachers = new HashSet<Teacher>();
        }

        public ShoolClass(IEnumerable<Student> students, IEnumerable<Teacher> teachers)
        {
            this.studentsByNumber = new Dictionary<uint, Student>();
            this.AddStudents(students.ToArray());

            this.Teachers = new HashSet<Teacher>(teachers);
        }

        public ICollection<Student> Students => this.studentsByNumber.Values;

        public ICollection<Teacher> Teachers { get; }

        public Comment Comment { get; set; }

        public void AddStudent(Student student)
        {
            student.AssignClassNumber(this.nextStudentNumber++);
            this.studentsByNumber.Add(student.ClassNumber, student);
            student.ShoolClasses.Add(this);
        }

        public void AddStudents(params Student[] newStudents)
        {
            foreach (var student in newStudents)
            {
                this.AddStudent(student);
            }
        }

        public Student RemoveStudent(uint classNumber)
        {
            var student = this.studentsByNumber[classNumber];

            if (student == null)
            {
                throw new ArgumentException("No student found with the given class number");
            }

            this.studentsByNumber.Remove(classNumber);
            student.ShoolClasses.Remove(this);

            return student;
        }
    }
}
