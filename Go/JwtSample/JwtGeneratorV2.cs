using System;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using VaultSharp;
using VaultSharp.V1.Commons;
using VaultSharp.V1.AuthMethods;
using VaultSharp.V1.AuthMethods.Token;

public class JwtGeneratorV2
{
    private IVaultClient vaultClient;

    public JwtGeneratorV2()
    {
        // Authenticate
        IAuthMethodInfo authMethod = new TokenAuthMethodInfo(vaultToken: "hvs.rL9m7w3JTVPnvzTYA6pnNfra");
        // Initialize Vault client
        VaultClientSettings vaultClientSettings = new VaultClientSettings("http://host.docker.internal:8200", authMethod);
        vaultClient = new VaultClient(vaultClientSettings);
    }

    public async Task<string> GenerateJwt(string userId)
    {
        var secretKey = await GetOrGenerateSecretKey();

        Console.WriteLine($"SecretKey v2 : {secretKey}");

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(secretKey);
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

    private async Task<string> GetOrGenerateSecretKey()
    {
        Secret<SecretData> secret;

        try
        {
            // Read a secret
            secret = vaultClient.V1.Secrets.KeyValue.V2.ReadSecretAsync(
                path: "/my-secret",
                mountPoint: "secret"
            ).Result;
        }
        catch
        {
            // If the secret key doesn't exist, generate a new one and store it in Vault
            var keyGenerator = new SecretKeyGenerator();
            var newSecretKey = keyGenerator.GenerateSecretKey();

            var secretData = new Dictionary<string, object> { { "key", newSecretKey } };
            vaultClient.V1.Secrets.KeyValue.V2.WriteSecretAsync(
                path: "/my-secret",
                data: secretData,
                mountPoint: "secret"
            ).Wait();

            return newSecretKey;
        }

        return secret.Data.Data["key"].ToString();
    }
}