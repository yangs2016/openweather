using Yang.Weather.DataAccess.Contracts;
using Yang.Weather.DataAccess.Config;
using Yang.Weather.DataAccess.Models;

namespace Yang.Weather.DataAccess.Dao
{
    public class WeatherDao: BaseDao, IWeatherDao
    {
        public WeatherDao(IDataStoreConfigurationProvider configProvider) : base(configProvider)
        {}
        public IReadOnlyList<WeatherCondition>? GetWeatherByGeocodeId(int geoCodeId)
        {
            return FindMultiple<WeatherCondition>(w=> w.GeoCodeId == geoCodeId)?.ToList();
        }

        public WeatherCondition? GetWeatherConditionByWeatherId(int id)
        {
            return FindSingleOrDefault<WeatherCondition>(w => w.Id == id);
        }

        public int SaveWeatherCondition(WeatherCondition weather)
        {
            return Create<WeatherCondition>(weather)>0? weather.Id:0;
        }
    }
}
