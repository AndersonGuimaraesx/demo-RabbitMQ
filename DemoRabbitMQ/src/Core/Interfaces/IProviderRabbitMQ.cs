using Core.Enum;

namespace Core.Interfaces
{
    public interface IProviderRabbitMQ
    {
        ExampleType ExampleType { get; }
        void DeclareWorker();
        void Publish();
        void Consume();
    }
}
