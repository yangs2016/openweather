using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yang.Weather.DataAccess.Models;

namespace Yang.Weather.DataAccess.Contracts
{
    public interface IGeoCodeDao
    {
        GeoCode? GetGeoCode(int id);

        int CreateGeoCode(GeoCode geoCode);

        IReadOnlyList<GeoCode>? GetAllGeoCodes();

        IReadOnlyList<GeoCode>? GetGeocodeByZipcode(string zipcode);
    }
}
