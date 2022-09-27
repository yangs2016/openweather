using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yang.Weather.Business.Enums;

namespace Yang.Weather.Business.Models.GoogleMapApi
{
    public class AddressComponent
    {
        public string? LongName { get; set; }
        public string? ShortName { get; set; }
        public string[]? Types { get; set; }
    }
}
