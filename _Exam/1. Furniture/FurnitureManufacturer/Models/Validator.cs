namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Validator
    {
        public static void CheckIfNull (object obj, string message = null)
        {
            if (obj == null)
            {
                throw new NullReferenceException(message);
            }
        }

        public static void CheckIfNullOrEmpty (string str, string message = null)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new NullReferenceException(message);
            }
        }

        public static void CheckIfExactNumberOfSymbols(string str, int n, string message = null)
        {
            if (str.Length != n)
            {
                throw new ArgumentException(message);
            }
        }
        public static void CheckIfLessNumberOfSymbols(string str, int n, string message = null)
        {
            if (str.Length < n)
            {
                throw new ArgumentException(message);
            }
        }

        public static void CheckIfAllSymbolsAreDigits(string str, string message = null)
        {
            foreach (char symbol in str)
            {
                if (!char.IsDigit(symbol))
                {
                    throw new ArgumentException(message);
                }
            }
        }

        public static void CheckIfLessOrEqualToZero(decimal number, string message = null)
        {
            if (number <= 0)
            {
                throw new ArgumentException(message);
            }
        }

    }
}
