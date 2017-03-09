namespace Telerik.Homeworks.OOP.Principles.StudentsAndWorkers.Generators
{
    public class StudentsGenerator : SimpleGenerator<Student>
    {
        protected override Student GenerateType(string[] textData)
        {
            var student = new Student(
                textData[1],
                textData[2],
                this.GenerateGrade());

            return student;
        }

        private int GenerateGrade()
        {
            int grade = Random.Next(Student.MinGrade, Student.MaxGrade + 1);

            return grade;
        }
    }
}
