using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySqlNonDocker.DataAccess;
using MySqlNonDocker.Models;

namespace MySqlNonDocker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherRepository weatherRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherRepository weatherRepository)
        {
            _logger = logger;
            this.weatherRepository = weatherRepository;
            _logger.LogInformation($"Using repo: {weatherRepository.GetType().Name}");
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return this.weatherRepository.GetWeatherForecastsAsync().Result;
        }
    }
}
