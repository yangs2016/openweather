namespace Yang.Weather.DataAccess.Models
{
    public class GeoCode
    {
        public int Id { get; set; }
        public float Latitude { get; set; }   
        public float Longitude { get; set; }
        public string Postalcode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
