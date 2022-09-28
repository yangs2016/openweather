using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yang.Weather.DataAccess.Contracts;
using AutoMapper;
using Yang.Weather.DataAccess.Config;
using Yang.Weather.DataAccess.Models;

namespace Yang.Weather.DataAccess.Dao
{
    public class GeoCodeDao: BaseDao, IGeoCodeDao
    {
        public GeoCodeDao(IDataStoreConfigurationProvider configProvider) : base(configProvider)
        {}

        public int CreateGeoCode(GeoCode geoCode)
        {
            int saved= Create<GeoCode>(geoCode);
            
            return saved>0? geoCode.Id:0;
        }

        public IReadOnlyList<GeoCode>? GetAllGeoCodes()
        {
            return FindMultiple<GeoCode>(s => s.Id > 0)?.ToList();
        }

        public GeoCode? GetGeoCode(int id)
        {
            return FindFirstOrDefault<GeoCode>(s =>s.Id == id);
        }
    }
}
