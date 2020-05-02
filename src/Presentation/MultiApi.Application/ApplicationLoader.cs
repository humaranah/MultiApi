using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiApi.Application.Helpers;
using MultiApi.Module.Configurators;

namespace MultiApi.Application
{
    public static class ApplicationLoader
    {
        public static IServiceCollection AddModuleServices(this IServiceCollection services, IConfiguration configuration)
        {
            var configurators = ModulesIntegrationHelper.FindInstancesOf<IModuleServicesConfigurator>();
            foreach (var configurator in configurators)
            {
                configurator.RegisterServices(services, configuration);
            }

            return services;
        }

        public static void ConfigureModules(this IApplicationBuilder app, bool isDevelopment)
        {
            var configurators = ModulesIntegrationHelper.FindInstancesOf<IModuleConfigurator>();
            foreach (var configurator in configurators)
            {
                configurator.Configure(app, isDevelopment);
            }
        }
    }
}
