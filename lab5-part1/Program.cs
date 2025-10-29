using System;
using System.Diagnostics;

namespace lab5_part1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter first number: ");
                string input1 = Console.ReadLine();
                Console.Write("Enter second number: ");
                string input2 = Console.ReadLine();

                double num1 = Convert.ToDouble(input1);
                double num2 = Convert.ToDouble(input2);

                double result = DivideNumbers(num1, num2);

                // Check for special cases with floating-point division
                if (double.IsInfinity(result))
                {
                    throw new DivideByZeroException("Division by zero is not allowed.");
                }

                Console.WriteLine($"Result: {result}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter valid numbers only.");
                LogToEventViewer("FormatException: Invalid number format");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                LogToEventViewer($"DivideByZeroException: {ex.Message}");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: The number is too large or too small.");
                LogToEventViewer("OverflowException: Number out of range");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                LogToEventViewer($"General Exception: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Operation completed.");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

        static double DivideNumbers(double num1, double num2)
        {
            return num1 / num2;
        }

        static void LogToEventViewer(string message)
        {
            try
            {
                using (EventLog eventLog = new EventLog("Application"))
                {
                    eventLog.Source = "Application";
                    eventLog.WriteEntry(message, EventLogEntryType.Error, 101, 1);
                    Console.WriteLine($"Logged to Event Viewer: {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to log to Event Viewer: {ex.Message}");
            }
        }
    }
}