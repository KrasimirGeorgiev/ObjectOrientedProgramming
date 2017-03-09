namespace Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /**
     * Problem 9. Student groups
     * Create a class Student with properties FirstName, LastName, FN, Tel, 
     * Email, Marks (a List), GroupNumber.
     */
    public class Student
    {
        internal IList<int> MarksList;

        public Student(
            string fname, string lname, int age, int groupNumber)
        {
            this.FirstName = fname;
            this.LastName = lname;
            this.Age = age;
            this.GroupNumber = groupNumber;
        }

        /// <summary>
        /// Internal constructor to be used by the generators
        /// </summary>
        internal Student()
        {
        }

        public string FirstName { get; internal set; }

        public string LastName { get; internal set; }

        public int Age { get; internal set; }

        public int FacultyNumber { get; internal set; }

        public string Phone { get; set; }

        public IList<int> Marks
        {
            get
            {
                if (this.MarksList == null)
                {
                    return null;
                }
                else
                {
                    return this.MarksList.Take(this.MarksList.Count).ToArray();
                }
            }
        }

        public string Email { get; set; }

        public int GroupNumber { get; set; }

        public override string ToString()
        {
            int padding = 4;

            var strBuilder = new StringBuilder();

            strBuilder
                .AppendFormat(
                    "Student: {0}\n"
                    , this.FacultyNumber != 0 ? this.FacultyNumber.ToString() : string.Empty)
                .AppendFormat("Name: {0} {1}\n".PadLeft(padding), this.FirstName, this.LastName)
                .AppendFormat("Age: {0} Group: {1}\n".PadLeft(padding), this.Age, this.GroupNumber)
                .AppendFormat("Email: {0} Phone: {1}".PadLeft(padding), this.Email, this.Phone);

            return strBuilder.ToString();
        }

        public void AddMark(int mark)
        {
            this.MarksList.Add(mark);
        }

        public void RemoveMark(int mark)
        {
            this.MarksList.Remove(mark);
        }
    }
}
