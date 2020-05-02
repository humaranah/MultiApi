using Microsoft.AspNetCore.Builder;

namespace MultiApi.Module.Configurators
{
    public interface IModuleConfigurator
    {
        void Configure(IApplicationBuilder app, bool isDevelopment);
    }
}
