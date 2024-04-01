using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

public static class PasswordHelper
{
    private const int DefaultPasswordLength = 8;
    private static readonly string PasswordChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
    private static readonly string SpecialChars = "!@#$%^&*()";
    private static readonly Regex PasswordRegex = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,}$");

    public static bool IsValid(string password)
    {
        return PasswordRegex.IsMatch(password);
    }

    public static string GeneratePassword(int length = DefaultPasswordLength)
    {
        var rng = new RNGCryptoServiceProvider();
        var password = new char[length];

        for (int i = 0; i < length - 1; i++)
        {
            byte[] buffer = new byte[sizeof(uint)];
            rng.GetBytes(buffer);
            uint num = BitConverter.ToUInt32(buffer, 0);
            password[i] = PasswordChars[(int)(num % PasswordChars.Length)];
        }

        // Ensure the generated password passes the IsValid check
        password[length - 1] = SpecialChars[rng.GetNonZeroBytes(1)[0] % SpecialChars.Length];

        return new string(password);
    }
}