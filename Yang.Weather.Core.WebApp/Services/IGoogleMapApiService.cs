using Microsoft.Build.Framework;
using Newtonsoft.Json;
using RestSharp;
using Yang.Weather.Business.Models.GoogleMapApi;
using Yang.Weather.Core.WebApp.Config;

namespace Yang.Weather.Business.Services
{
    public class GoogleMapApiService : IGoogleMapApiService
    {
        private readonly IAppSettingsConfigProvider _config;
        public GoogleMapApiService(IAppSettingsConfigProvider settingsConfigProvider)
        { 
            _config = settingsConfigProvider;
        }
        public GoogleMapApiResult? QueryGeocoding(Address address)
        {
            var mapApiBaseUrl = _config.GoogleMapApiUrl;
            var apiKey = _config.GoogleMapApiKey;

            var options = new RestClientOptions(mapApiBaseUrl)
            {
                ThrowOnAnyError = true,
                MaxTimeout = 2000
            };

            var client = new RestClient(options);
            var request = new RestRequest()
                .AddQueryParameter("address", $"{address.AdressLine1},{address.AdressLine2},{address.City},{address.State},{address.PostalCode},{address.Country}")
                .AddQueryParameter("key", apiKey);

            var response = client.Get(request);

            if (response.IsSuccessStatusCode && response?.Content != null)
            {
                GoogleMapApiResponse? result = JsonConvert.DeserializeObject<GoogleMapApiResponse>(response.Content, new JsonSerializerSettings()
                {
                    ContractResolver = new GoogleMapApiContractResolver()
                });

                return result?.results !=null && result?.results.Length>0? result.results[0]: null;
            }

            return null;
        }

    }
    
    public interface IGoogleMapApiService
    {
        GoogleMapApiResult? QueryGeocoding(Address address);
    }
}
