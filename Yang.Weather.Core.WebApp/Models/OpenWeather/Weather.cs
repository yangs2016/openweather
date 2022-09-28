using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yang.Weather.Business.Models.OpenWeather
{
    public class Weather
    {
        public int Id { get; set; }
        public string Main { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string Icon { get; set; } = string.Empty;

    }
    public class Main
    {
        public float Temp { get; set; }
        public float FeelsLike { get; set; }
        public float TempMin { get; set; }
        public float TempMax { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public int SeaLevel { get; set; }
        public int GrounLevel { get; set; }

    }

    public class Wind
    {
        public float Speed { get; set; }
        public int Deg { get; set; }
        public float Gust { get; set; }
    }
    public class Clouds
    {
        public string All { get; set; } = string.Empty;
    }
    public class Coord
    {
        public float Lon { get; set; }
        public float Lat { get; set; }
    }

    public class Rain
    {
        public string OneHour { get; set; }

        public string ThreeHour { get; set; }

    }
    public class Snow
    {
        public string OneHour { get; set; }

        public string ThreeHour { get; set; }

    }

    public class Sys
    {
        public int Type { get; set; }
        public int Id { get; set; }
        public string Country { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }

    }


}
