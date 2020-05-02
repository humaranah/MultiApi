using MultiApi.Domain.WeatherForecast;
using MultiApi.Infrastructure.WeatherForecast.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiApi.Infrastructure.WeatherForecast.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        public ServiceResponse<IEnumerable<WeatherForecastData>> GetData(int count)
        {
            if (count < 0)
            {
                return ServiceResponse<IEnumerable<WeatherForecastData>>
                    .BuildFailure("Negative count is not allowed.");
            }

            if (count == 0)
            {
                return ServiceResponse<IEnumerable<WeatherForecastData>>
                    .BuildSuccess(Array.Empty<WeatherForecastData>());
            }

            var rng = new Random();
            var data = Enumerable.Range(1, count).Select(index => new WeatherForecastData
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = WeatherConstants.Summaries[rng.Next(WeatherConstants.Summaries.Length)]
            })
            .ToArray();

            return ServiceResponse<IEnumerable<WeatherForecastData>>.BuildSuccess(data);
        }
    }
}
