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
                double num1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter second number: ");
                double num2 = Convert.ToDouble(Console.ReadLine());

                double result = DivideNumbers(num1, num2);
                Console.WriteLine($"Result: {result}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: Invalid input format. {ex.Message}");
                LogToEventViewer($"FormatException: {ex.Message}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error: Cannot divide by zero. {ex.Message}");
                LogToEventViewer($"DivideByZeroException: {ex.Message}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"Error: Number is too large or too small. {ex.Message}");
                LogToEventViewer($"OverflowException: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                LogToEventViewer($"General Exception: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Operation completed.");
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
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to log to Event Viewer: {ex.Message}");
            }
        }
    }
}