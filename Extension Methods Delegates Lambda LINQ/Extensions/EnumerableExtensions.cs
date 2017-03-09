namespace Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /** 
    * Problem 2. IEnumerable extensions
    *   Implement a set of extension methods for IEnumerable<T> that implement the 
    *   following group functions: sum, product, min, max, average.
    * Problem 6. Divisible by 7 and 3
    *   Write a program that prints from given array of integers all numbers that are divisible
    *   by 7 and 3. Use the built-in extension methods and lambda expressions. Rewrite the 
    *   same with LINQ.
    * Problem 17. Longest string
    *   Write a program to return the string with maximum length from an array of strings.
    *   Use LINQ.
    */
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Returns the smallest element in the enumeration
        /// Throws an exception if the enumeration is empty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elements"></param>
        /// <returns>Returns the smallest element in the enumeration</returns>
        /// <exception cref="InvalidOperationException">
        /// Throws an exception if the enumeration is empty
        /// </exception>
        public static T Min<T>(this IEnumerable<T> elements)
            where T : IComparable<T>
        {
            T min;

            using (IEnumerator<T> enumerator = elements.GetEnumerator())
            {
                min = FitstOrThrow(enumerator);
                while (enumerator.MoveNext())
                {
                    T current = enumerator.Current;
                    if (current.CompareTo(min) < 0)
                    {
                        min = current;
                    }
                }
            }

            return min;
        }

        /// <summary>
        /// Returns the bigest element in the enumeration
        /// Throws an exception if the enumeration is empty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elements"></param>
        /// <returns>Returns the bigest element in the enumeration</returns>
        /// <exception cref="InvalidOperationException">
        /// Throws an exception if the enumeration is empty
        /// </exception>
        public static T Max<T>(this IEnumerable<T> elements)
            where T : IComparable<T>
        {
            T max;

            using (IEnumerator<T> enumerator = elements.GetEnumerator())
            {
                max = FitstOrThrow(enumerator);
                while (enumerator.MoveNext())
                {
                    T current = enumerator.Current;
                    if (current.CompareTo(max) > 0)
                    {
                        max = current;
                    }
                }
            }

            return max;
        }

        /// <summary>
        /// Sums the elements of the collection if they are of numeric type
        /// throws an exception if they are not numeric
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elements"></param>
        /// <returns>Returns the sum of all elements</returns>
        /// <exception cref="ArgumentException">
        /// Throws an exception if the Enumeration is not of numeric type
        /// </exception>
        public static T Sum<T>(this IEnumerable<T> elements)
            where T : struct, IComparable<T>
        {
            ValidateNumericType(typeof(T));
            dynamic sum = default(T);

            foreach (var element in elements)
            {
                sum += element;
            }

            return sum;
        }

        /// <summary>
        /// Multiplies the elements of the collection if they are of numeric type
        /// throws an exception if they are not numeric
        /// throws an exception if there is an overflow
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elements"></param>
        /// <returns>Returns the product of all elements</returns>
        /// <exception cref="ArgumentException">
        /// Throws an exception if the Enumeration is not of numeric type
        /// </exception>
        /// <exception cref="OverflowException">
        /// In case the number overlows an exception is thrown
        /// </exception>
        public static T Product<T>(this IEnumerable<T> elements)
            where T : struct, IComparable<T>
        {
            ValidateNumericType(typeof(T));
            dynamic product = 1;

            foreach (var element in elements)
            {
                // Checks for overflow
                checked
                {
                    product *= element;
                }
            }

            return product;
        }

        /// <summary>
        /// Determines the average of the elements
        /// throws an exception if they are not numeric
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elements"></param>
        /// <returns>Returns the elements average value</returns>
        /// <exception cref="ArgumentException">
        /// Throws an exception if the Enumeration is not of numeric type
        /// </exception>
        public static double Average<T>(this IEnumerable<T> elements)
            where T : struct, IComparable<T>
        {
            ValidateNumericType(typeof(T));
            double counter = 0;
            dynamic sum = default(T);

            foreach (var element in elements)
            {
                counter++;
                sum += element;
            }

            return sum / counter;
        }

        /// <summary>
        /// Returns a collection of the numbers that are divisible without reminder
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        public static IEnumerable<int> DivisibleBy(this IEnumerable<int> numbers, int divisor)
        {
            // var divisible = numbers.Where(n => n%number == 0);

            var divisible =
                from number in numbers
                where number % divisor == 0
                select number;

            return divisible;
        }

        /// <summary>
        /// Returns the longest string of a collection of strings
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        public static string LongestString(this IEnumerable<string> strings)
        {
            var result = strings
                .OrderByDescending(s => s.Length)
                .FirstOrDefault();

            return result;
        }

        /// <summary>
        /// Uesd internally to get the first element of an enumeration
        /// without causing re-enumration on the elements
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerator"></param>
        /// <returns>Returns the first element of the enumeration or throws and exception</returns>
        /// <exception cref="InvalidOperationException">Thrown if the enumeration is empty</exception>
        private static T FitstOrThrow<T>(IEnumerator<T> enumerator)
        {
            T result;

            if (enumerator.MoveNext())
            {
                result = enumerator.Current;
            }
            else
            {
                throw new InvalidOperationException("The enumeration doesn't contain any elements");
            }

            return result;
        }

        private static void ValidateNumericType(Type type)
        {
            if (type != typeof(Int16) &&
                type != typeof(Int32) &&
                type != typeof(Int64) &&
                type != typeof(UInt16) &&
                type != typeof(UInt32) &&
                type != typeof(UInt64) &&
                type != typeof(float) &&
                type != typeof(double) &&
                type != typeof(decimal))
            {
                throw new ArgumentException("The type is not numeric");
            }
        }
    }
}