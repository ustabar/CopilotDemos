using System;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        string text = "My email is john.doe@example.com and my phone number is 123-456-7890. My credit card number is 1234-5678-9012-3456.";
        Console.WriteLine(RemovePii(text));
    }

    public static string RemovePii(string text)
    {
        // Email addresses
        text = Regex.Replace(text, @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b", "[REDACTED]");

        // Phone numbers
        text = Regex.Replace(text, @"\b(\+\d{1,2}\s?)?1?\-?\.?\s?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}\b", "[REDACTED]");

        // Credit card numbers
        text = Regex.Replace(text, @"\b\d{4}[\s-]?\d{4}[\s-]?\d{4}[\s-]?\d{4}\b", "[REDACTED]");

        return text;
    }
}