// See https://aka.ms/new-console-template for more information

using Azure;
using Azure.AI.OpenAI;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;

var builder = new ConfigurationBuilder()
    // .SetBasePath(Directory.GetCurrentDirectory())
    .SetBasePath(@"C:\Codes\CoPilotApp\Demos\OpenAIChallenges\ChatWithSQLConsole\")
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

IConfigurationRoot configuration = builder.Build();

string? settingValue = configuration["MySetting"];
string? oaiEndpoint = configuration["AzureOAIEndpoint"];
string? oaiKey = configuration["AzureOAIKey"];
string? oaiDeploymentName = configuration["AzureOAIDeploymentName"];

Console.WriteLine("\nEnter a prompt: ");
string userPrompt = Console.ReadLine() ?? "";

string Question;
List<List<string>> RowData;
string Summary;
string Query;
string Error;

DataTable? dataTable;

await GetResponseFromOpenAI(userPrompt);

async Task GetResponseFromOpenAI(string prompt)
{
    Console.WriteLine("\nCalling Azure OpenAI...\n\n");

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
    string systemPrompt = @"You are a helpful, friendly, 
                and knowledgeable assistant. 
                Table schema name is 'SalesLT'.
                Use the following database schema 
                when responding to user queries:

                - Address (AddressID, AddressLine1, AddressLine2, City, StateProvince, CountryRegion, PostalCode, rowguid, ModifiedDate)
                - Customer (CustomerID, NameStyle, Title, FirstName, MiddleName, LastName, Suffix, CompanyName, SalesPerson, EmailAddress, Phone, PasswordHash, PasswordSalt, rowguid, ModifiedDate)
                - CustomerAddress (CustomerID, AddressID, AddressType, rowguid, ModifiedDate)
                - Product (ProductID, Name, ProductNumber, Color, StandardCost, ListPrice, Size, Weight, ProductCategoryID, ProductModelID, SellStartDate, SellEndDate, DiscontinuedDate, ThumbNailPhoto, ThumbnailPhotoFileName, rowguid, ModifiedDate)
                - ProductCategory (ProductCategoryID, ParentProductCategoryID, Name, rowguid, ModifiedDate)
                - ProductDescription (ProductDescriptionID, Description, rowguid, ModifiedDate)
                - ProductModel (ProductModelID, Name, CatalogDescription, rowguid, ModifiedDate)
                - ProductModelProductDescription (ProductModelID, ProductDescriptionID, Culture, rowguid, ModifiedDate)
                - SalesOrderDetail (SalesOrderID, SalesOrderDetailID, OrderQty, ProductID, UnitPrice, UnitPriceDiscount, LineTotal, rowguid, ModifiedDate)
                - SalesOrderHeader (SalesOrderID, RevisionNumber, OrderDate, DueDate, ShipDate, Status, OnlineOrderFlag, SalesOrderNumber, PurchaseOrderNumber, AccountNumber, CustomerID, ShipToAddressID, BillToAddressID, ShipMethod, CreditCardApprovalCode, SubTotal, TaxAmt, Freight, TotalDue, Comment, rowguid, ModifiedDate)
                
                Include column name headers in the query results.
                
                Always provide your answer in the JSON format below:
                
                { ""summary"": ""your-summary"", ""query"": ""your-query""}
                
                Ouput ONLY JSON.
                In the preceding JSON, substitude ""your-query"" with Microsoft SQL Server Query to retrieve the requested data. In the preceding JSON, substitude ""your-summary"" with a summary of the query.
                Always use schema name with table name.
                Always include all columns in the query results.
                Do not use MySQL syntax.";
    
    string userPrompt = prompt;

    // Format and send the request to the model
    ChatCompletionsOptions options = new ChatCompletionsOptions()
    {
        Messages =
        {
            new ChatMessage(ChatRole.System, systemPrompt),
            new ChatMessage(ChatRole.System, prompt)
        },
        Temperature = 0.7f,
        MaxTokens = 1000,
        NucleusSamplingFactor = (float)0.95,
        FrequencyPenalty = 0,
        PresencePenalty = 0
    };

    /*
    // Get response from Azure OpenAI
    Response<ChatCompletions> response = 
        await client.GetChatCompletionsAsync(oaiDeploymentName, chatCompletionsOptions);

    ChatCompletions completions = response.Value;
    string completion = completions.Choices[0].Message.Content;
    */
    Response<ChatCompletions> response =
    await client.GetChatCompletionsAsync(oaiDeploymentName, options);

    ChatCompletions completions = await client.GetChatCompletionsAsync(oaiDeploymentName, options);
    string completion = completions.Choices[0].Message.Content
                        .Replace("```json", "")
                        .Replace("```", "");
                        
    var res = JsonSerializer.Deserialize<AIQuery>(completion);

    Summary = res.summary;
    Query = res.query;
    // RowData = DataService.GetDataTable(res.query);

    /*
    // Print column names
    for (int i = 0; i < RowData.Columns.Count; i++)
    {
        Console.Write("{0,-20}", RowData.Columns[i].ColumnName);
    }
    Console.WriteLine();

    // Print row data
    foreach (DataRow row in RowData.Rows)
    {
        for (int i = 0; i < RowData.Columns.Count; i++)
        {
            Console.Write("{0,-20}", row[i]);
        }
        Console.WriteLine();
    }
    */

    Console.WriteLine(Summary);
    Console.WriteLine("\n");
    Console.WriteLine(Query);
    Console.ReadLine();
}