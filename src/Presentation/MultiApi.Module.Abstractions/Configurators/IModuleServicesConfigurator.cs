using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MultiApi.Module.Configurators
{
    public interface IModuleServicesConfigurator
    {
        void RegisterServices(IServiceCollection services, IConfiguration configuration);
    }
}
