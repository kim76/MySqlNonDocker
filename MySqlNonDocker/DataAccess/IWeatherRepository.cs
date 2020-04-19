using MySqlNonDocker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySqlNonDocker.DataAccess
{
    public interface IWeatherRepository
    {
        public Task<List<WeatherForecast>> GetWeatherForecastsAsync();
    }
}
