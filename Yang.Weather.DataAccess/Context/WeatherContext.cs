using Microsoft.EntityFrameworkCore;
using Yang.Weather.DataAccess.Models;

namespace Yang.Weather.DataAccess.Context
{
    public class WeatherContext : DbContext
    {
        public WeatherContext (DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<WeatherCondition> WeatherCondition { get; set; } = default!;
        public DbSet<GeoCode> GeoCode { get; set; } = default!;

        
    }
}
