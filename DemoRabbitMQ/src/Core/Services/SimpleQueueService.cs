using Core.Enum;
using Core.Interfaces;
using Core.Model;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

namespace Core.Services
{
    public class SimpleQueueService : IProviderRabbitMQ
    {
        public ExampleType ExampleType => ExampleType.Simple;
        private readonly ConnectionFactory _factory;
        private readonly Worker _worker = new Worker();

        public SimpleQueueService()
        {
            var queue = new Queue("qu-simple", false, false, false, null);
            var basicPublish = new BasicPublish(string.Empty, queue.QueueName, null, Encoding.UTF8.GetBytes("Hello World!"));
            _worker.Create(queue, basicPublish);

            _factory = new ConnectionFactory() { HostName = "localhost" };
        }

        public void DeclareWorker()
        {
            using (var connection = _factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: _worker.Queue.QueueName, durable: _worker.Queue.Durable,
                        exclusive: _worker.Queue.Exclusive, autoDelete: _worker.Queue.AutoDelete, arguments: _worker.Queue.Arguments);
                }
            }
        }

        public void Publish()
        {
            using (var connection = _factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.BasicPublish(exchange: _worker.BasicPublish.Exchange, routingKey: _worker.BasicPublish.RoutingKey,
                        basicProperties: _worker.BasicPublish.BasicProperties, body: _worker.BasicPublish.Body);
                }
            }
        }

        public void Consume()
        {
            using (var connection = _factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var consumer = new EventingBasicConsumer(channel);

                    consumer.Received += (model, ea) =>
                    {
                        try
                        {
                            var body = ea.Body.ToArray();

                            Console.WriteLine($"{DateTime.Now} [x] Received: {Encoding.UTF8.GetString(body)}");

                            channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                        }
                        catch (Exception ex)
                        {
                            channel.BasicNack(deliveryTag: ea.DeliveryTag, multiple: false, requeue: false);
                        }
                    };


                    channel.BasicConsume(queue: _worker.Queue.QueueName, autoAck: false, consumer: consumer);

                    Console.WriteLine("Conectado.");

                    while (true)
                    {
                    }
                }
            }

        }
    }
}
