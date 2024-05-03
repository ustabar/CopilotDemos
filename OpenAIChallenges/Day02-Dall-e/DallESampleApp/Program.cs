using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Azure.AI.OpenAI;
using Azure;
using System.Collections.Generic;

class Program
{
    private static IConfiguration Configuration { get; set; }
    private static OpenAIClient? Client { get; set; }

    static async Task Main(string[] args)
    {
        Configuration = new ConfigurationBuilder()
            .AddJsonFile(@"C:\Codes\CoPilotApp\Demos\OpenAIChallenges\Day02-Dall-e\DallESampleApp\appsettings.json", true, true)
            .Build();

        string folderName = Configuration["AzureOAI:folderName"];
        string aoaiKey = Configuration["AzureOAI:aoaiKey"];
        string aoaiURL = Configuration["AzureOAI:aoaiURL"];
        string model = Configuration["AzureOAI:model"];
        string imgSize = Configuration["AzureOAI:imgSize"];

        // Console.WriteLine($"Key: {aoaiURL}");
        // Console.WriteLine($"URL: {aoaiKey}");
        // Console.ReadKey();

        if (aoaiURL != null && aoaiKey != null)
        {
            Client = new OpenAIClient(
                new Uri(aoaiURL),
                new AzureKeyCredential(aoaiKey));
        }

        var imagePrompts = GetImagePrompts();

        foreach (var imagePrompt in imagePrompts)
        {
            await GenerateAndDownloadImage(imagePrompt.Item1, imagePrompt.Item2);
        }

        Console.WriteLine("\n\n Press any key to exit.");
        // Console.ReadKey();
    }

    private static List<Tuple<string, string>> GetImagePrompts()
    {
        // This could be replaced with a database or file read operation
        return new List<Tuple<string, string>>
        {
            /*
            // Yapay Zeka ve Makine Öğrenimi
            Tuple.Create("AIandML.jpg", "Yapay zeka algoritmaları geliştiren kadın ve erkek mühendislerin, yapay zeka konseptlerini simgeleyen ikonlar ve formüller ile çevrili olduğu bir çalışma alanı."),
            // Veri Analizi ve Büyük Veri
            Tuple.Create("DataAnalysis.jpg", "Erkek ve kadın veri bilimcilerinin, renkli veri görselleştirmeleri ve büyük veri setleri ile dolu çoklu ekranlar önünde düşünceli bir şekilde çalıştığı bir resim."),
            // Donanım Mühendisliği
            Tuple.Create("HardwareEngineering.jpg", "Kadın ve erkek donanım mühendislerinin, mikroişlemciler, devre kartları ve elektronik bileşenler ile dolu bir çalışma masasında montaj yaptığı bir sahne."),
            // Ağ ve Güvenlik
            Tuple.Create("NetworkSecurity.jpg", "Erkek ve kadın ağ mühendislerinin, güvenlik duvarları ve ağ topolojileri içeren bir ağ izleme merkezinde çalıştığını gösteren bir sahne."),
            // Robotik ve Otomasyon
            Tuple.Create("RoboticsAutomation.jpg", "Erkek ve kadın robotik mühendislerinin, gelişmiş robot kolları ve otomasyon panelleri ile dolu bir laboratuvarda çalıştığını gösteren bir görüntü."),
            // Yazılım Geliştirme            
            Tuple.Create("SoftwareDevelopment.jpg", "Erkek ve kadın yazılım mühendislerinin bilgisayar ekranında karmaşık kod satırları ile dolu bir geliştirme ortamında kodlama yaparken gösteren dijital illüstrasyon."),
            // Yazılım Testi ve Kalite Güvencesi
            Tuple.Create("SoftwareTesting.jpg", "Erkek ve kadin kalite güvence mühendislerinin, hata raporları ve test sonuçları ile dolu ekranlar arasında geçiş yaptığı bir test laboratuvarı ortamı."),
            // Sistem Analizi ve Tasarımı
            Tuple.Create("SystemAnalysis.jpg", "Erkek ve kadın sistem analistlerinin, büyük bir monitörde iş akışı diyagramları ve sistem mimarisi planlarını inceleyen bir ofis ortamında çalışıyorken göster.")
            */
            /*
            // Computer Engineering
            Tuple.Create("ComputerEngineer.jpg", "Kontrol ve bilgisayar mühendisliğinin temel unsurlarını vurgulayan bir görsel tasarla. Görselde iki kısım olsun. Bir tanesinde bir öğrenci üniversitede ders çalışırken, diğerinde ise bir mühendis bir yazılım üzerinde çalışırken göster.")
            */

            // Github Copilot
            // Tuple.Create("Copilot.jpg", "Github Copilot'un, bir yazılım geliştiriciye kod yazarken yardımcı olduğu bir sahneyi tasvir et. Görselde bir yazılım geliştirici, bilgisayar ekranında kod yazarken, Copilot'un kod önerilerini gözden geçirirken göster.")
            Tuple.Create("Copilot.jpg", "kod yazarken zorlanan bir programcıyı resimle")
        };
    }

    private static async Task GenerateAndDownloadImage(string fileName, string prompt)
    {
        var imageGenerationOptions = new ImageGenerationOptions
        {
            Prompt = prompt,
            DeploymentName = Configuration["AzureOAI:model"],
            Size = new ImageSize(Configuration["AzureOAI:imgSize"]),
            ImageCount = 1
        };

        try
        {
            var response = await Client.GetImageGenerationsAsync(imageGenerationOptions);
            string res = response.Value.Data[0].Url.AbsoluteUri;

            await DownloadImage(res, fileName);

            Console.WriteLine($"Download completed. {fileName} has been created.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating image: {ex.Message}");
        }
    }

    private static async Task DownloadImage(string url, string fileName)
    {
        using (var downloadClient = new HttpClient())
        {
            var imageBytes = await downloadClient.GetByteArrayAsync(url);
            File.WriteAllBytes($"{Configuration["AzureOAI:folderName"]}{fileName}", imageBytes);
        }
    }
}