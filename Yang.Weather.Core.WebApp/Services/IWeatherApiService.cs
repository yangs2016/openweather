using Newtonsoft.Json;
using RestSharp;
using Yang.Weather.Business.Models.OpenWeather;
using Yang.Weather.Business.Models.GoogleMapApi;
using System.Diagnostics;
using Yang.Weather.Core.WebApp.Config;

namespace Yang.Weather.Business.Services
{
    public interface IWeatherApiService
    {
        OpenWeatherApiResponse? QueryWeatherCondition(GeoCode coord);
    }

    public class WeatherApiService : IWeatherApiService
    {
        private readonly IAppSettingsConfigProvider _config;
        public WeatherApiService(IAppSettingsConfigProvider appSettingsConfigProvider)
        { 
            _config = appSettingsConfigProvider;
        }

        public OpenWeatherApiResponse? QueryWeatherCondition(GeoCode coord)
        {
            var apiBaseUrl = _config.OpenWeatherApiUrl;
            var apiKey = _config.OpenWeatherAppId;

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
