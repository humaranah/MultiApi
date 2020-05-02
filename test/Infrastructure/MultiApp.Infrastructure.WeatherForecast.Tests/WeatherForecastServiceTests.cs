using MultiApi.Infrastructure.WeatherForecast.Services;
using Xunit;

namespace MultiApp.Infrastructure.WeatherForecast.Tests
{
    public class WeatherForecastServiceTests
    {
        private IWeatherForecastService _service;

        public WeatherForecastServiceTests()
        {
            _service = new WeatherForecastService();
        }

        [Fact]
        public void Call_GetDataWithZeroParameter_ReturnsEmptyArray()
        {
            var result = _service.GetData(0);
            Assert.True(result.IsSuccess);
            Assert.Empty(result.Data);
            Assert.Null(result.ErrorMessage);
        }

        [Fact]
        public void Call_GetData_ReturnsSpecifiedItemCount()
        {
            var result = _service.GetData(1);
            Assert.True(result.IsSuccess);
            Assert.Single(result.Data);
            Assert.Null(result.ErrorMessage);
        }

        [Fact]
        public void Call_GetDataWithNegativeParameter_ReturnsFailure()
        {
            var result = _service.GetData(-1);
            Assert.False(result.IsSuccess);
            Assert.Null(result.Data);
            Assert.NotEmpty(result.ErrorMessage);
        }
    }
}
