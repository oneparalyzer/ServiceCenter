using Microsoft.Extensions.DependencyInjection;
using oneparalyzer.ServiceCenter.UseCases.Implementations;
using oneparalyzer.ServiceCenter.UseCases.Interfaces;
using oneparalyzer.ServiceCenter.UseCases.Mapping;


namespace oneparalyzer.ServiceCenter.UseCases.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceCenter(this IServiceCollection services)
        {
            services.AddScoped<IServiceUseCase, ServiceUseCase>();
            services.AddScoped<IOrderUseCase, OrderUseCase>();
            services.AddScoped<IClientUseCase, ClientUseCase>();
            services.AddScoped<ISpareUseCase, SpareUseCase>();
            services.AddAutoMapper(typeof(MappingConfiguration));
            return services;
        }
    }
}
