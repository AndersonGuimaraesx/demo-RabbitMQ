using Microsoft.Extensions.DependencyInjection;
using Core.UseCase;

namespace Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = InjectionServiceProvider.Inject();
            var service = provider.GetService<StartWorkRabbitMQ>();
            service.Publish();
        }
    }
}
