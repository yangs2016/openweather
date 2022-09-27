using Microsoft.Extensions.Configuration;
using Yang.Weather.Core.WebApp.Pages;
using Yang.Weather.DataAccess.Config;


namespace Yang.Weather.Core.WebApp.Config
{
    public class AppConfigurationProvider : IDataStoreConfigurationProvider
    {
        private readonly IConfiguration _configuration;

        public AppConfigurationProvider(IConfiguration config)
        {
            _configuration = config;
        }
        public string ConnectionString => _configuration.GetConnectionString("WeatherDbContext"); 
    }
}
