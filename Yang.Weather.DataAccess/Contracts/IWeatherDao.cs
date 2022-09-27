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
        WeatherCondition? GetWeatherConditionByWeatherId(int Id);

        IReadOnlyList<WeatherCondition>? GetWeatherByGeocodeId(int geoCodeId);

        int SaveWeatherCondition(WeatherCondition weather);


    }
}
