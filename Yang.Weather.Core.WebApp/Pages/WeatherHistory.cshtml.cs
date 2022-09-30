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
        private readonly IGeoCodeDao _geoCodeDao;

        public IReadOnlyList<WeatherCondition>? WeatherHistory { get; set; }

        public string WeatherHistoryStatus { get; set; } = string.Empty;

        public class QueryModel
        {
            public string Zip { get; set; } = string.Empty;
            public DateTime StartDate { get; set; }

            public DateTime EndDate { get; set; }
        }

        public WeatherHistoryModel(IWeatherDao weatherDao, IGeoCodeDao geoDao)
        { 
            _weatherDao = weatherDao;  
            _geoCodeDao = geoDao;
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

        public void OnGetHist(string zip, DateTime startDate, DateTime endDate)
        {
            try
            {
                var geoCodes = _geoCodeDao.GetGeocodeByZipcode(zip);

                if (geoCodes != null && geoCodes.Count > 0)
                {
                    var weatherHist = _weatherDao.GetWeatherByGeocodes(geoCodes.Select(c => c.Id).ToArray());

                    if (weatherHist != null && weatherHist.Count > 0)
                    {
                        WeatherHistory = weatherHist
                                .Where(w => w.CreatedDate >= startDate && w.CreatedDate <= endDate)
                               .OrderBy(w => w.CreatedDate).ToList();

                        WeatherHistoryStatus = $"Number of weather reports available from database for zipcode {zip} between {startDate} and {endDate}: {WeatherHistory.Count()}";
                    }

                    else
                    {
                        WeatherHistoryStatus = $"No records found from database for zipcode {zip} between {startDate} and {endDate}";
                    }
                }
                else
                {
                    WeatherHistoryStatus = $"No Geocoding records found from database for zipcode {zip} between {startDate} and {endDate}";
                }

            }
            catch (Exception ex)
            {
                RedirectToPage("Error", new { errorMessage = ex.Message });
            }

        }
    }
}
