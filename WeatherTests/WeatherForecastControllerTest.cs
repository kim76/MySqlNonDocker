using Microsoft.Extensions.Logging;
using Moq;
using MySqlNonDocker.Controllers;
using MySqlNonDocker.DataAccess;
using MySqlNonDocker.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace WeatherTests
{
    public class WeatherForecastControllerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetForecast_NoParams_ReturnsListOfForecasts()
        {
            //arrange
            int forecastCount = 4;
            Mock<IWeatherRepository> mockRepo = GetForecasts(forecastCount);
            var sut = new WeatherForecastController(new Mock<ILogger<WeatherForecastController>>().Object, mockRepo.Object);

            //act
            var result = sut.Get();

            //assert
            Assert.AreEqual(forecastCount, result.Count);
        }

        private static Mock<IWeatherRepository> GetForecasts(int count)
        {
            var mockRepo = new Mock<IWeatherRepository>();
            List<WeatherForecast> forecasts = new List<WeatherForecast>();
            for (int i = 0; i < count; i++)
            {
                var forecast = new WeatherForecast
                {
                    Id = i,
                    Date = System.DateTime.UtcNow,
                    Summary = $"This is summary {i}",
                    TemperatureC = i * 5
                };
                forecasts.Add(forecast);
            }
            mockRepo.Setup(c => c.GetWeatherForecastsAsync()).ReturnsAsync(forecasts);
            return mockRepo;
        }
    }
}