namespace Yang.Weather.Core.WebApp.Config
{
    public interface IAppSettingsConfigProvider
    {
        string GoogleMapApiKey { get;  }
        string GoogleMapApiUrl { get; }
        string OpenWeatherApiUrl { get; }
        string OpenWeatherAppId { get; }
    }
}
