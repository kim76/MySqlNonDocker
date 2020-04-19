using Microsoft.EntityFrameworkCore;
using MySqlNonDocker.Models;

namespace MySqlNonDocker.DataAccess
{
    public class WeatherContext : DbContext
    {
        public WeatherContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}
