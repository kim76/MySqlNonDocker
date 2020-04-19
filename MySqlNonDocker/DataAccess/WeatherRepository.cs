using Microsoft.EntityFrameworkCore;
using MySqlNonDocker.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySqlNonDocker.DataAccess
{
    public class WeatherRepository : IWeatherRepository
    {
        private WeatherContext context;

        public WeatherRepository(WeatherContext context)
        {
            this.context = context;
        }

        public Task<List<WeatherForecast>> GetWeatherForecastsAsync()
        {
            return this.context.WeatherForecasts.ToListAsync();
        }
    }
}
