namespace VersionAttribute
{
    using System;

    [System.AttributeUsage(AttributeTargets.Class |
                           AttributeTargets.Struct |
                           AttributeTargets.Interface |
                           AttributeTargets.Method |
                           AttributeTargets.Enum)]
    public class SpecialVersionAttribute : Attribute
    {
        public SpecialVersionAttribute(int major = 1, int minor = 0)
        {
            this.Major = major;
            this.Minor = minor;
        }

        public int Major { get; }

        public int Minor { get; }

        public override string ToString()
        {
            return $"{this.Major}.{this.Minor}";
        }
    }
}
