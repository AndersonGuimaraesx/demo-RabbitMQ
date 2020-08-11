using Core.UseCase;
using Microsoft.Extensions.DependencyInjection;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = InjectionServiceProvider.Inject();
            var service = provider.GetService<StartWorkRabbitMQ>();
            service.Consume();
        }
    }
}
