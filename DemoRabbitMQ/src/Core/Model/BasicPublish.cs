using RabbitMQ.Client;
using System;

namespace Core.Model
{
    public class BasicPublish
    {
        public string Exchange { get; private set; }
        public string RoutingKey { get; private set; }
        public IBasicProperties BasicProperties { get; private set; }
        public ReadOnlyMemory<byte> Body { get; private set; }

        public BasicPublish(string exchange, string routingKey, IBasicProperties basicProperties, ReadOnlyMemory<byte> body)
        {
            Exchange = exchange;
            RoutingKey = routingKey;
            BasicProperties = basicProperties;
            Body = body;
        }
    }
}
