using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Yang.Weather.Console.Test
{
    public class GoogleMapApiContractResolver : DefaultContractResolver
    {
        private Dictionary<string, string> _porpertyMappings { get; set; }

        public GoogleMapApiContractResolver()
        {
            _porpertyMappings = new Dictionary<string, string>()
            {
                {"AddressComponents", "address_components" },
                {"LongName","long_name" },
                {"ShortName", "short_name" },
                {"Types","types"},
                {"Latitude","lat" },
                {"Longitude", "lng" },
                {"LocationType","location_type" },
                {"Formatted","formatted_address" },
                {"PlaceId","place_id" },
                {"StreetNumber","street_number" },
                {"AdministrativeAreaLevel2","administrative_area_level_2"},
                {"AdministrativeAreaLevel1","administrative_area_level_1"},
                {"PostalCode","postal_code" },
                {"PostalCodeSuffix","postal_code_suffix" }

            };

        }

        protected override string ResolvePropertyName(string propertyName)
        {
            string? resolvedName = null;
            var resolved = _porpertyMappings.TryGetValue(propertyName, out resolvedName);

            return resolved && resolvedName!=null? resolvedName: base.ResolvePropertyName(propertyName);
        }
    }
}
