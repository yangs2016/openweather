using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yang.Weather.Business.Enums;
using Newtonsoft.Json;

namespace Yang.Weather.Business.Models.GoogleMapApi
{
    public class Bounds
    {
        public GeoCode? NorthEast { get; set; }

        public GeoCode? SouthWest { get; set; }

        public GeoCode? NorthWest { get; set; }

        public GeoCode? SouthEast { get; set; }

    }
}
