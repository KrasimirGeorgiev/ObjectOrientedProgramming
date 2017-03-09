namespace Extensions
{
    using System.Text;

    public static class StringBuilderExtensions
    {
        /** Problem 1. StringBuilder.Substring 
         * Implement an extension method Substring(int index, int length) for the class 
         * StringBuilder that returns new StringBuilder and has the same functionality as 
         * Substring in the class String.
         */
        public static StringBuilder Substring(this StringBuilder sb, int index, int length)
        {
            return new StringBuilder(sb.ToString(index, length));
        }
    }
}