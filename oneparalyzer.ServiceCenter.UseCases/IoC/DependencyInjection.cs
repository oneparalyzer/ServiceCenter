using Microsoft.Extensions.DependencyInjection;
using oneparalyzer.ServiceCenter.UseCases.Interfaces;
using oneparalyzer.ServiceCenter.UseCases.Mapping;


namespace oneparalyzer.ServiceCenter.UseCases.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceCenter(this IServiceCollection services)
        {
            services.AddScoped<IServiceUseCase, IServiceUseCase>();
            services.AddAutoMapper(typeof(MappingConfiguration));
            return services;
        }
    }
}
