using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiApi.Infrastructure.WeatherForecast.Services;
using MultiApi.Module.Configurators;

namespace MultiApi.Module.WeatherForecast.Configurators
{
    public class WeatherForecastServicesConfigurator : IModuleServicesConfigurator
    {
        public void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddSingleton<IWeatherForecastService, WeatherForecastService>();
        }
    }
}
