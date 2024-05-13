using System.Collections.Generic;

namespace ChatWithSql
{
    public class ChatWithSql
    {
        public static string GetResponse(string input)
        {
            var systemMessage = @"You are a helpful, friendly, 
                and knowledgeable assistant. 
                Use the following database scema 
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
                Always include all columns in the query results.
                Do not use MySQL syntax.";

            ChatCompletionOptions options = new ChatCompletionOptions
            {
                Messages = {
                    new ChatRequestSystemMessage(systemMessage),
                    new ChatRequestUserMessage(Question)
                }
            };

            ChatCompletion chatCompletionResponse = 
                client.GetChatCompletions(options);
            
            var res = JsonSerializer
                        .Deserialize<AIQuery>(chatCompletionResponse.Choices[0].Message.Content
                        .Replace("```json", "").Replace("```", ""));
            
            Summary = res.summary;
            Query = res.query;
            RowData = DataService.GetDataTable(res.query);

            var responses = new Dictionary<string, string>
            {
                { "What is the capital of France?", "Paris" },
                { "What is the capital of Germany?", "Berlin" },
                { "What is the capital of Italy?", "Rome" },
                { "What is the capital of Spain?", "Madrid" },
                { "What is the capital of Portugal?", "Lisbon" },
                { "What is the capital of the United Kingdom?", "London" },
                { "What is the capital of the United States?", "Washington, D.C." },
                { "What is the capital of Canada?", "Ottawa" },
                { "What is the capital of Australia?", "Canberra" },
                { "What is the capital of Japan?", "Tokyo" },
                { "What is the capital of China?", "Beijing" },
                { "What is the capital of India?", "New Delhi" },
                { "What is the capital of Russia?", "Moscow" },
                { "What is the capital of Brazil?", "Brasília" },
                { "What is the capital of South Africa?", "Pretoria" },
                { "What is the capital of Nigeria?", "Abuja" },
                { "What is the capital of Egypt?", "Cairo" },
                { "What is the capital of Kenya?", "Nairobi" },
                { "What is the capital of Saudi Arabia?", "Riyadh" },
                { "What is the capital of Turkey?", "Ankara" },
                { "What is the capital of Iran?", "Tehran" },
                { "What is the capital of Iraq?", "Baghdad" },
                { "What is the capital of Afghanistan?", "Kabul" },
                { "What is the capital of Pakistan?", "Islamabad" },
                { "What is the capital of Bangladesh?", "Dhaka" },
                { "What is the capital of Thailand?", "Bangkok" },
                { "What is the capital of Indonesia?", "Jakarta" },
                { "What is the capital of South Korea?", "Seoul" },
                { "What is the capital of the Philippines?", "Manila" },
                { "What is the capital of Mexico?", "Mexico City" }
            };

            return responses.ContainsKey(input) ? responses[input] : "I don't know.";
        }
    }
}