using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yang.Weather.DataAccess.Models;

namespace Yang.Weather.DataAccess.Contracts
{
    public interface IWeatherDao
    {
        /// <summary>
        /// Get weather by weather id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        WeatherCondition? GetWeatherConditionByWeatherId(int Id);

        /// <summary>
        /// Get a list of weather conditions fpr a specific Geocoding Id
        /// </summary>
        /// <param name="geoCodeId"></param>
        /// <returns></returns>
        IReadOnlyList<WeatherCondition>? GetWeatherByGeocodeId(int geoCodeId);

        /// <summary>
        /// Get a list of weather condition for an array of Geocode Ids
        /// </summary>
        /// <param name="geoCodeIds"></param>
        /// <returns></returns>
        IReadOnlyList<WeatherCondition>? GetWeatherByGeocodes(int[] geoCodeIds);

        /// <summary>
        /// Save weather to database and return the weather's identity
        /// </summary>
        /// <param name="weather"><see cref="WeatherCondition"/></param>
        /// <returns></returns>
        int SaveWeatherCondition(WeatherCondition weather);

        /// <summary>
        /// Search weather conditions for a specific date range
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        IReadOnlyList<WeatherCondition>? GetWeatherConditionsByDates(DateTime start, DateTime end);


    }
}
