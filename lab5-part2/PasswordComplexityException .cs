using System;

namespace lab5_part2
{
    // Custom Exception Class
    public class PasswordComplexityException : Exception
    {
        public PasswordComplexityException() : base("Password must be at least 8 characters long.")
        {
        }

        public PasswordComplexityException(string message) : base(message)
        {
        }

        public PasswordComplexityException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}