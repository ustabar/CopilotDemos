using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Azure.AI.OpenAI;
using Azure;
class Program
{
    static async Task Main(string[] args)
    {
        const string folderName = "C:\\Codes\\CoPilotApp\\Demos\\OpenAIChallenges\\Day02-Dall-e\\DallESampleApp\\DownloadedImages\\";
        const string aoaiKey = "c5c31b1c1aaa4919ba701fbcec03f2f8";
        const string aoaiURL = "https://barutaidemo.openai.azure.com/";
        const string model = "dalledemo";
        const string imgSize = "1024x1024";
        string fileName = Guid.NewGuid().ToString() + ".jpg";        

        var prompt = new StringBuilder();
        prompt.Append("A cartoon character with spiky blue hair and ");
        prompt.Append("emerald green eyes, wearing a traditional ");
        prompt.Append("cricket uniform consisting of a white shirt,");
        prompt.Append("trousers, and a red cricket cap. "); 
        prompt.Append("This character is striking a cricket ball ");
        prompt.Append("with a willow bat in the middle of a vast, ");
        prompt.Append("well-maintained football field. The field is ");
        prompt.Append("vibrant green and has white line markings, ");
        prompt.Append("with two goal posts at each end. ");
        prompt.Append("The sky above is a cheerful cerulean with ");
        prompt.Append("a few fluffy cumulus clouds scattered about.");

        var imageGenerationOptions = new ImageGenerationOptions
        {
            Prompt = prompt.ToString(),
            DeploymentName = model,
            Size = new ImageSize(imgSize),
            ImageCount = 1
        };

        try 
        {
            OpenAIClient client = new OpenAIClient(
                new Uri(aoaiURL),
                new AzureKeyCredential(aoaiKey));

                        var response = await client.GetImageGenerationsAsync(imageGenerationOptions);
            string res = response.Value.Data[0].Url.AbsoluteUri;

            using (var downloadClient = new HttpClient())
            {
                var imageBytes = await downloadClient.GetByteArrayAsync(res);
                File.WriteAllBytes($"{folderName}{fileName}", imageBytes);
            }

            Console.WriteLine($"Download completed. {fileName} has been created. \n\n Press any key to exit.");
        } 
        catch (Exception ex) 
        {
            Console.WriteLine($"Error creating image: {ex.Message}");        
        } 
        Console.ReadKey();
    }
}