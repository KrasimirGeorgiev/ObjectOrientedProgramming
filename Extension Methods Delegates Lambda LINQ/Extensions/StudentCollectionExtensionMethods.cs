namespace Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public static class StudentCollectionExtensionMethods
    {
        /** 
         *  Problem 3. First before last
         *  Write a method that from a given array of students finds all students whose 
         *      first name is before its last name alphabetically.
         *  Use LINQ query operators.
         */
        public static IEnumerable<Student> GetFirstBeforeLast(this IEnumerable<Student> students)
        {
            var result =
                from student in students
                where string.Compare(student.FirstName, student.LastName, StringComparison.Ordinal) < 0
                select student;

            return result;
        }

        /**
         * Problem 4. Age range
         * Write a LINQ query that finds the first name and last name of all students with 
         * age between 18 and 24.
         */
        public static IEnumerable<Student> GetStudentsOfAge(
            this IEnumerable<Student> students, int minAge, int maxAge)
        {
            var result =
                from student in students
                where minAge <= student.Age && student.Age <= maxAge
                select student;

            return result;
        }

        /**
         * Problem 5. Order students
         * Using the extension methods OrderBy() and ThenBy() with lambda expressions sort 
         *      the students by first name and last name in descending order.
         *  Rewrite the same with LINQ.
         */
        public static IEnumerable<Student> OrderByFullName(this IEnumerable<Student> students)
        {
            //var ordered = students
            //    .OrderByDescending(s => s.FirstName)
            //    .ThenByDescending(s => s.LastName);

            var ordered =
                from student in students
                orderby student.FirstName descending, student.LastName descending
                select student;

            return ordered;
        }

        /**
         * Problem 9 & 10. Student groups extensions
         * Create a List<Student> with sample students. Select only the students that are 
         * from group number 2.
         * Use LINQ query. Order the students by FirstName.
         * Implement the previous using the same query expressed with extension methods.
         */
        public static IEnumerable<Student> StudentsOfGroup(
            this IEnumerable<Student> students, int groupNumber)
        {
            //var ordered =
            //    from student in students
            //    where student.GroupNumber == groupNumber
            //    orderby student.FirstName
            //    select student;

            var ordered = students
                .Where(s => s.GroupNumber == groupNumber)
                .OrderBy(s => s.FirstName);

            return ordered;
        }

        /** Problem 11. Extract students by email
         * Extract all students that have email in abv.bg.
         * Use string methods and LINQ.
         */
        public static IEnumerable<Student> StudentsOfDomain(
            this IEnumerable<Student> students, string domainName)
        {
            var result =
                from student in students
                where IsOfDomain(domainName, student.Email)
                select student;

            return result;
        }

        /**
         * Problem 12. Extract students by phone
         * Extract all students with phones in Sofia.
         * Use LINQ.
         */
        public static IEnumerable<Student> StudentsWithPhoneCode(
            this IEnumerable<Student> students, string phoneCode)
        {
            var result =
                from student in students
                where student.Phone.StartsWith(phoneCode)
                select student;

            return result;
        }

        /**
         * Problem 18 & 19. Grouped by GroupNumber
         * Create a program that extracts all students grouped by GroupNumber and then
         * prints them to the console.
         * Rewrite the previous using extension methods.
         */
        public static IEnumerable<IGrouping<int, Student>> GroupStudentsByGroupNumber(
            this IEnumerable<Student> students)
        {
            var result = students
                .GroupBy(s => s.GroupNumber);

            return result;
        }

        private static bool IsOfDomain(string domain, string email)
        {
            var parts = email.Split('@');
            if (parts.Length != 2)
            {
                return false;
            }

            return domain == parts[1];
        }
    }
}
