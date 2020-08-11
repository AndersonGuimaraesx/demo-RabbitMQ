using Core.Enum;
using Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Core.UseCase
{
    public class StartWorkRabbitMQ
    {
        private readonly IEnumerable<IProviderRabbitMQ> _providerRabbitMQs;

        public StartWorkRabbitMQ(IEnumerable<IProviderRabbitMQ> providerRabbitMQs)
        {
            _providerRabbitMQs = providerRabbitMQs;
        }

        public void CreateWorker()
        {
            _providerRabbitMQs.FirstOrDefault(x => x.ExampleType == ExampleType.Simple).DeclareWorker();
        }

        public void Publish()
        {
            _providerRabbitMQs.FirstOrDefault(x => x.ExampleType == ExampleType.Simple).Publish();
        }

        public void Consume()
        {
            _providerRabbitMQs.FirstOrDefault(x => x.ExampleType == ExampleType.Simple).Consume();
        }
    }
}
