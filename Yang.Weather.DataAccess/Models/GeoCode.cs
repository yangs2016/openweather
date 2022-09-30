namespace Yang.Weather.DataAccess.Models
{
    public class GeoCode
    {
        public int Id { get; set; }
        public decimal Latitude { get; set; }   
        public decimal Longitude { get; set; }
        public string Postalcode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
