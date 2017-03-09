namespace Telerik.Homeworks.OOP.Principles.Validation
{
    using System;

    public static class Validator
    {
        public const int MinNameLength = 3;
        public const int MaxNameLength = 20;

        public static string ValidateName(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), "A person name cannot be null");
            }

            value = value.Trim();

            if (value.Length < MinNameLength)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "The given name is too short");
            }

            if (value.Length > MaxNameLength)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "The given name is too long");
            }

            return value;
        }

        public static int ValidateNumber(int number, int minValue, int maxValue)
        {
            if (number < minValue || maxValue < number)
            {
                throw new ArgumentOutOfRangeException(nameof(number), "The number value is invalid");
            }

            return number;
        }
    }
}
