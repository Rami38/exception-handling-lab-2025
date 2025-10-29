using System;

namespace lab5_part2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter your password: ");
                string password = Console.ReadLine();

                CheckPasswordComplexity(password);
                Console.WriteLine("Password is valid!");
            }
            catch (PasswordComplexityException ex)
            {
                Console.WriteLine($"Password Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }

        static void CheckPasswordComplexity(string password)
        {
            if (string.IsNullOrEmpty(password) || password.Length < 8)
            {
                throw new PasswordComplexityException();
            }
        }
    }
}