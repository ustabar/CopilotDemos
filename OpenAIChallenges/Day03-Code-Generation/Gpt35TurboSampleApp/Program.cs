// See https://aka.ms/new-console-template for more information
// Note: The Azure OpenAI client library for .NET is in preview.
// Install the .NET library via NuGet: dotnet add package Azure.AI.OpenAI --version 1.0.0-beta.5

using Azure;
using Azure.AI.OpenAI;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder()
    // .SetBasePath(Directory.GetCurrentDirectory())
    .SetBasePath(@"C:\Codes\CoPilotApp\Demos\OpenAIChallenges\Day03-Code-Generation\Gpt35TurboSampleApp\")
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

IConfigurationRoot configuration = builder.Build();

string? settingValue = configuration["MySetting"];
string? oaiEndpoint = configuration["AzureOAIEndpoint"];
string? oaiKey = configuration["AzureOAIKey"];
string? oaiDeploymentName = configuration["AzureOAIDeploymentName"];

string command;
bool printFullResponse = false;

do
{
    Console.WriteLine("\n1: Add comments to my function\n" +
                        "2: Write unit tests for my function\n" +
                        "3: Fix my Go Fish game\n" +
                        "\"quit\" to exit the program\n\n" +
                        "Enter a number to select a task:");

    command = Console.ReadLine() ?? "";

    if (command == "quit")
    {
        Console.WriteLine("Exiting program...");
        break;
    }

    Console.WriteLine("\nEnter a prompt: ");
    string userPrompt = Console.ReadLine() ?? "";
    string codeFile = "";

    if (command == "1" || command == "2")
        codeFile = System.IO.File.ReadAllText(@"C:\Codes\CoPilotApp\Demos\OpenAIChallenges\Day03-Code-Generation\Gpt35TurboSampleApp\sample-code\function\function.cs");
    else if (command == "3")
        codeFile = System.IO.File.ReadAllText(@"C:\Codes\CoPilotApp\Demos\OpenAIChallenges\Day03-Code-Generation\Gpt35TurboSampleApp\sample-code\go-fish\go-fish.cs");
    else
    {
        Console.WriteLine("Invalid input. Please try again.");
        continue;
    }

    userPrompt += codeFile;

    await GetResponseFromOpenAI(userPrompt);
} while (true);

async Task GetResponseFromOpenAI(string prompt)
{
    Console.WriteLine("\nCalling Azure OpenAI to generate code...\n\n");

    if (string.IsNullOrEmpty(oaiEndpoint) || 
        string.IsNullOrEmpty(oaiKey) || 
        string.IsNullOrEmpty(oaiDeploymentName))
    {
        Console.WriteLine("Please check your appsettings.json file for missing or incorrect values.");
        return;
    }

    // Configure the Azure OpenAI client
    OpenAIClient client = new OpenAIClient(
                                new Uri(oaiEndpoint), 
                                new AzureKeyCredential(oaiKey));

    // Define chat prompts
    string systemPrompt = "You are a helpful AI assistant that helps programmers write code.";
    string userPrompt = prompt;

    // Format and send the request to the model
    var chatCompletionsOptions = new ChatCompletionsOptions()
    {
        Messages =
        {
            new ChatMessage(ChatRole.System, 
                @"You are a helpful AI assistant that helps programmers write code."),
            new ChatMessage(ChatRole.System, prompt)
        },
        Temperature = 0.7f,
        MaxTokens = 1000,
        NucleusSamplingFactor = (float)0.95,
        FrequencyPenalty = 0,
        PresencePenalty = 0
    };

    // Get response from Azure OpenAI
    Response<ChatCompletions> response = 
        await client.GetChatCompletionsAsync(oaiDeploymentName, chatCompletionsOptions);

    ChatCompletions completions = response.Value;
    string completion = completions.Choices[0].Message.Content;

    // Write full response to console, if requested
    if (printFullResponse)
    {
        Console.WriteLine($"\nFull response: {JsonSerializer.Serialize(completions, new JsonSerializerOptions { WriteIndented = true })}\n\n");
    }

    // Write the file.
    System.IO.File.WriteAllText(@"C:\Codes\CoPilotApp\Demos\OpenAIChallenges\Day03-Code-Generation\Gpt35TurboSampleApp\result\app.txt", completion);

    // Write response to console
    Console.WriteLine($"\nResponse written to result/app.txt\n\n");
}