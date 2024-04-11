using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public class JwtGenerator
{
    // private const string SecretKey = "this_is_a_longer_secret_key_that_is_at_least_32_characters"; // Replace with your secret key
    public string GenerateJwt(string userId)
    {
        var keyGenerator = new SecretKeyGenerator();
        var SecretKey = keyGenerator.GenerateSecretKey();

        Console.WriteLine($"SecretKey v1 : {SecretKey}");

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(SecretKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] 
            {
                new Claim("sub", userId)
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}