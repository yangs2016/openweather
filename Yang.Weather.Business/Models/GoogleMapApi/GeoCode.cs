using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yang.Weather.Business.Models.GoogleMapApi
{
    public class GeoCode
    {
        public int Id { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string? PlaceId { get; set; }
        public string? PostalCode { get; set; }

    }
}
