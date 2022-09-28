using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yang.Weather.Business.Models.GoogleMapApi
{
    public class GoogleMapApiResult
    {
        public AddressComponent[] AddressComponents { get; set; }
        public Geometry Geometry { get; set; }
        public string PlaceId { get; set; }

        public string[] Types { get; set; }

        public GoogleMapApiResult(AddressComponent[] addressComponents, Geometry geometry, string placeId, string[] types)
        {
            AddressComponents = addressComponents;
            Geometry = geometry;
            PlaceId = placeId;
            Types = types;
        }
    }

    public class GoogleMapApiResponse
    {
        public GoogleMapApiResult[]? results { get; set; }
    }
}
