using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Yang.Weather.Business.Services
{
    public class OpenWeatherApiContractResolver : DefaultContractResolver
    {
        private Dictionary<string, string> _porpertyMappings { get; set; }

        public OpenWeatherApiContractResolver()
        {
            _porpertyMappings = new Dictionary<string, string>()
            {
                {"OneHour", "1h" },
                {"ThreeHour","3h" },
                {"SeaLevel", "sea_level" },
                {"GroundLevel","grnd_level"},
                {"TempMax","temp_max" },
                {"TempMin", "temp_min" },
                {"FeelsLike","feels_like" }
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
