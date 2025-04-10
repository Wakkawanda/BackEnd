using System.Text;
using Newtonsoft.Json;

namespace BackEnd;

class Program
{
    //private static Settings.Settings s;
    
    private static readonly HttpClient client = new HttpClient();
    private static readonly string apiUrl = "https://localhost:7100/api/items"; // Замените на URL вашего API

    static async Task Main(string[] args)
    {
        Console.WriteLine("Connecting to API...");

        await GetItems();
        await AddItem("New Item from Console");
        await GetItems(); // Get items again to see the added item

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }

    static async Task GetItems()
    {
        try
        {
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();  // Throws exception if status code is not successful.
            string responseBody = await response.Content.ReadAsStringAsync();

            // Десериализация JSON ответа в список строк (или другой нужный тип)
            var items = JsonConvert.DeserializeObject<string[]>(responseBody);  // Предполагаем, что API возвращает массив строк

            Console.WriteLine("\nItems:");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
    }

    static async Task AddItem(string newItem)
    {
        try
        {
            string json = JsonConvert.SerializeObject(newItem);  // Сериализуем строку в JSON
            var content = new StringContent(json, Encoding.UTF8, "application/json");  // Указываем Content-Type

            HttpResponseMessage response = await client.PostAsync(apiUrl, content);
            response.EnsureSuccessStatusCode();

            Console.WriteLine("\nItem added successfully.");
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
    }
    
    //string d = File.ReadAllText("C:\\Users\\verao\\Desktop\\BackEnd\\BackEnd\\BackEnd\\Configuration.json");
    //s = JsonConvert.DeserializeObject<Settings.Settings>(d)!;
}