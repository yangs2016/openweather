using Newtonsoft.Json;
using RestSharp;
using Yang.Weather.Business.Models.OpenWeather;
using Yang.Weather.Business.Models.GoogleMapApi;
using System.Diagnostics;

namespace Yang.Weather.Business.Services
{
    public interface IWeatherApiService
    {
        OpenWeatherApiResponse? QueryWeatherCondition(GeoCode coord);
    }

    public class WeatherApiService : IWeatherApiService
    {
        public OpenWeatherApiResponse? QueryWeatherCondition(GeoCode coord)
        {
            var apiBaseUrl = @"https://api.openweathermap.org/data/2.5/weather?"; //should get from config settings
            var apiKey = "800a3f8dc7a089347269a3957e059ee1"; //this should get from Azure keyvault
            var options = new RestClientOptions(apiBaseUrl)
            {
                ThrowOnAnyError = true,
                MaxTimeout = 2000
            };

            var client = new RestClient(options);
            var request = new RestRequest()
            .AddQueryParameter("lat", $"{coord.Latitude}")
            .AddQueryParameter("lon", $"{coord.Longitude}")
            .AddQueryParameter("appid", apiKey);


            try
            {
                var response = client.Get(request);
                if (response.IsSuccessStatusCode && response?.Content != null)
                {
                    var result = JsonConvert.DeserializeObject<OpenWeatherApiResponse>(response.Content, new JsonSerializerSettings()
                    {
                        ContractResolver = new OpenWeatherApiContractResolver()
                    });

                    return result;
                }
                return null;
            }
            catch (Exception e)
            {

                Debug.WriteLine(e.Message);
                return null;
            }
        }


    }
}
