using Core.Interfaces;
using Core.Services;
using Core.UseCase;
using Microsoft.Extensions.DependencyInjection;

namespace Consumer
{
    public static class InjectionServiceProvider
    {
        public static ServiceProvider Inject()
        {
            return new ServiceCollection()
              .AddTransient<IProviderRabbitMQ, SimpleQueueService>()
              .AddTransient<StartWorkRabbitMQ>()
              .BuildServiceProvider();
        }
    }
}
