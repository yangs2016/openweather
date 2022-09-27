using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Protocol;
using System.Diagnostics;
using Yang.Weather.Business.Models;
using Yang.Weather.Business.Models.GoogleMapApi;
using Yang.Weather.Business.Models.OpenWeather;
using Yang.Weather.Business.Services;
using Yang.Weather.DataAccess.Contracts;
using Yang.Weather.DataAccess.Models;

namespace Yang.Weather.Core.WebApp.Pages
{
    public class WeatherHistoryModel : PageModel
    {
        private readonly IWeatherDao _weatherDao;

        public IReadOnlyList<WeatherCondition>? WeatherHistory { get; set; }

        public string WeatherHistoryStatus { get; set; } = string.Empty;

        public WeatherHistoryModel(IWeatherDao dao)
        { 
            _weatherDao = dao;  
        }
        public void OnGet(int geocodeId)
        {
            try
            {
                var hist = _weatherDao.GetWeatherByGeocodeId(geocodeId);

                if (hist != null && hist.Count > 0)
                {
                    WeatherHistory = hist;
                    WeatherHistoryStatus = $"Number of weather reports available from database: {hist.Count}";
                }
            }
            catch (Exception ex)
            {
                RedirectToPage("Error", new { errorMessage = ex.Message });
            }

        }
    }
}
