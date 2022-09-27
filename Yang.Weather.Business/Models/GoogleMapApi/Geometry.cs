using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yang.Weather.Business.Enums;

namespace Yang.Weather.Business.Models.GoogleMapApi
{
    public class Geometry
    {
        public Bounds? Bounds { get; set; }
        public GeoCode? Location { get; set; }
        public string? LocationType { get; set; }
        public Bounds? ViewPort { get; set; }
    }
}
