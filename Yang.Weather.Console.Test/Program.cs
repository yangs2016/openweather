using Newtonsoft.Json;
using RestSharp;
using Yang.Weather.Business.Models.GoogleMapApi;
using Yang.Weather.Console.Test;


public class Program
{
    public static void Main()
    {
        //DeserializeFromFile(); //this works
        DeserializeFromApi();
    }

    static void DeserializeFromFile()
    {
        Console.WriteLine("Reading Api Json file...press Esc to cancel, Enter to start.");

        var key = Console.ReadKey();

        if (key.Key == ConsoleKey.Escape)
        {
            Console.WriteLine("Mission aborted.");
            return;
        }

        string jsonPath = @"C:\Development\Github\Yang.WeatherCondition\Yang.Weather.Console.Test\ApiResultSample.json";

        string json = File.ReadAllText(jsonPath);

        if (string.IsNullOrWhiteSpace(json))
        {
            Console.WriteLine($"Oohs, file not found...{jsonPath}");
            Console.ReadKey();
        }
        try
        {
            GoogleMapApiResult? result = JsonConvert.DeserializeObject<GoogleMapApiResult>(json, new JsonSerializerSettings() { ContractResolver = new GoogleMapApiContractResolver() });
            Console.WriteLine("Deserialization status...OK");
        }

        catch (Exception e)
        {
            Console.WriteLine(e.Message);

        }

    }

    static void DeserializeFromApi()
    {
        var mapApiBaseUrl = @"https://maps.googleapis.com/maps/api/geocode/json";
        var apiKey = "AIzaSyBi6I_cyEBGjPYnKBnCpRvwj6SXx8iVBD8";

       // https://maps.googleapis.com/maps/api/geocode/json?address=16363+ashington+park+dr.,%20+tampa,+fl&key=AIzaSyBi6I_cyEBGjPYnKBnCpRvwj6SXx8iVBD8");
        var options = new RestClientOptions(mapApiBaseUrl)
        {
            ThrowOnAnyError = true,
            MaxTimeout = 1000
        };

        var client = new RestClient(options);
        var request = new RestRequest()
            .AddQueryParameter("address", "16363 ashington park dr., tampa, fl 33647")
            .AddQueryParameter("key", apiKey);

        var response = client.Get(request);

        if (response.IsSuccessStatusCode && response?.Content != null)
        {
            GoogleMapApiResponse? result = JsonConvert.DeserializeObject<GoogleMapApiResponse>(response.Content, new JsonSerializerSettings()
            {
                ContractResolver = new GoogleMapApiContractResolver()
            });

            Console.WriteLine("OK");
        }

        else
        {
            Console.WriteLine("Response Not OK");
        }

    }

}
