using System;
using System.Security.Cryptography;
using System.Text;

public class SecretKeyGenerator
{
    public string GenerateSecretKey(int size = 32)
    {
        using (var rng = RandomNumberGenerator.Create())
        {
            var randomNumber = new byte[size];
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}