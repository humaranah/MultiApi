using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiApi.Infrastructure.WeatherForecast.Dto;
using MultiApi.Infrastructure.WeatherForecast.Services;
using System.Collections.Generic;

namespace MultiApi.Module.WeatherForecast
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _service;

        public WeatherForecastController(IWeatherForecastService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<WeatherForecastData>> Get()
        {
            var response = _service.GetData(5);
            if (!response.IsSuccess)
            {
                return BadRequest();
            }

            return Ok(response.Data);
        }
    }
}
