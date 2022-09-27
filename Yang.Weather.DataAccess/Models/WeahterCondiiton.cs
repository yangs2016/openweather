namespace Yang.Weather.DataAccess.Models
{
    public class WeatherCondition
    {
        public int Id { get; set; }
        public int GeoCodeId { get; set; }

        public double Temperature { get; set; }

        public string Condition { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdatedDate { get; set; }

    }
}
