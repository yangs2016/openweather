using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using Yang.Weather.Business.Models;
using ApiModel=Yang.Weather.Business.Models.GoogleMapApi;
using Yang.Weather.Business.Models.OpenWeather;
using Yang.Weather.Business.Services;
using Yang.Weather.DataAccess.Contracts;

namespace Yang.Weather.Core.WebApp.Pages
{
    public class WeatherModel : PageModel
    {
        private readonly IWeatherApiService _weatherApiService;
        private readonly IWeatherDao _weatherDao;

        public OpenWeatherApiResponse? WeatherCondition { get; set; }

        public ApiModel.GeoCode?  GeocodeModel { get; set; }

        public string WeatherDataSavedStatus { get; set; } = string.Empty;

        public WeatherModel(IWeatherApiService service, IWeatherDao dao)
        { 
            _weatherApiService = service;
            _weatherDao = dao;  
        }
        public void OnGet(ApiModel.GeoCode code)
        {
            if (code == null)
            {
                RedirectToPage("Error", new { errorMessage = $"Geocode was required to check weather condition but was not provided" });
                return;
            }
            GeocodeModel = code;

            var result =  _weatherApiService.QueryWeatherCondition(code);
            if (result != null)
            {
                WeatherCondition = result; //binding to view to display weather condition data

                var dataModel = new DataAccess.Models.WeatherCondition()
                {
                    GeoCodeId = code.Id,
                    Temperature = decimal.Parse((result.Main?.Temp ?? 0).ToString("0.00")),
                    Condition = $"Feel like {result.Main?.FeelsLike} Humidity: ${result.Main?.Humidity}",
                    CreatedDate = DateTime.UtcNow,
                    LastUpdatedDate = DateTime.UtcNow
                };

                try
                {
                    var saved = _weatherDao.SaveWeatherCondition(dataModel);
                    WeatherDataSavedStatus = saved > 0 ? $"Weather data has been saved to database successfully (Id: {saved})" : $"Weather data for locale ${result.Name} was not saved successfully. ";
                }

                catch (Exception ex)
                {
                    WeatherDataSavedStatus = $"Weather data was not saved successfully to database due to: {ex.Message}";
                }
            }

        }
    }
}
