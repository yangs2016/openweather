using Microsoft.Extensions.Configuration;
using Yang.Weather.Core.WebApp.Pages;
using Yang.Weather.DataAccess.Config;


namespace Yang.Weather.Core.WebApp.Config
{
    public class AppConfigurationProvider : IDataStoreConfigurationProvider, IAppSettingsConfigProvider
    {
        private readonly IConfiguration _configuration;

        public AppConfigurationProvider(IConfiguration config)
        {
            _configuration = config;
        }
        public string ConnectionString => _configuration.GetConnectionString("WeatherDbContext");

        public string GoogleMapApiKey => _configuration.GetValue<string>("GoogleMapApiKey");

        public string OpenWeatherAppId => _configuration.GetValue<string>("OpenWeatherApiKey");

        public string GoogleMapApiUrl => _configuration.GetValue<string>("GoogleMapApiUrl");


        public string OpenWeatherApiUrl => _configuration.GetValue<string>("OpenWeatherApiUrl");
    }
}
