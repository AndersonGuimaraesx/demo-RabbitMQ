using Core.Interfaces;
using Core.Services;
using Core.UseCase;
using Microsoft.Extensions.DependencyInjection;

namespace ManagerRabbitMQ
{
    public static class InjectionServiceProvider
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IProviderRabbitMQ, SimpleQueueService>();
            services.AddScoped<StartWorkRabbitMQ>();
        }
    }
}
