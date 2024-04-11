using System;
using System.Collections.Generic;
using VaultSharp;
using VaultSharp.V1.AuthMethods;
using VaultSharp.V1.AuthMethods.Token;
using VaultSharp.V1.Commons;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

JwtGenerator jwtGenerator = new JwtGenerator();
string jwt = jwtGenerator.GenerateJwt("123");
Console.WriteLine($"JWT v1 : @{jwt}");
Console.WriteLine("Press any key to continue >> 1 ...");
Console.ReadKey();

JwtGeneratorV2 jwtGeneratorV2 = new JwtGeneratorV2();
jwt = await jwtGeneratorV2.GenerateJwt("123");
Console.WriteLine($"JWT v2 : @{jwt}");
Console.WriteLine("Press any key to continue >> 2 ...");
Console.ReadKey();

// Authenticate
IAuthMethodInfo authMethod = new TokenAuthMethodInfo(vaultToken: "hvs.rL9m7w3JTVPnvzTYA6pnNfra");

VaultClientSettings vaultClientSettings = new VaultClientSettings("http://host.docker.internal:8200", authMethod);
IVaultClient vaultClient = new VaultClient(vaultClientSettings);

// Write a secret
var secretData = new Dictionary<string, object> { { "password", "Hashi123" } };
vaultClient.V1.Secrets.KeyValue.V2.WriteSecretAsync(
    path: "/my-secret-password",
    data: secretData,
    mountPoint: "secret"
).Wait();

Console.WriteLine("Secret written successfully.");

// Read a secret
Secret<SecretData> secret = vaultClient.V1.Secrets.KeyValue.V2.ReadSecretAsync(
    path: "/my-secret-password",
    mountPoint: "secret"
).Result;

var password = secret.Data.Data["password"];

Console.WriteLine(password);
Console.WriteLine("Press any key to exit...");
Console.ReadKey();