using MultiApi.Infrastructure.WeatherForecast.Dto;
using System.Collections.Generic;

namespace MultiApi.Infrastructure.WeatherForecast.Services
{
    public interface IWeatherForecastService
    {
        ServiceResponse<IEnumerable<WeatherForecastData>> GetData(int count);
    }
}
