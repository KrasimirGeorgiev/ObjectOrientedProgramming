namespace Models
{
    /**
     * Problem 16.* Groups
     * Create a class Group with properties GroupNumber and DepartmentName.
     */
    public class Group
    {
        public Group(int number, string department)
        {
            this.Number = number;
            this.DepartmentName = department;
        }

        public int Number { get; set; }

        public string DepartmentName { get; set; }
    }
}