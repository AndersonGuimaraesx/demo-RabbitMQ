using System.Collections.Generic;

namespace Core.Model
{
    public class Queue
    {
        public string QueueName { get; private set; }
        public bool Durable { get; private set; }
        public bool Exclusive { get; private set; }
        public bool AutoDelete { get; private set; }
        public IDictionary<string, object> Arguments { get; private set; }

        public Queue(string queueName, bool durable, bool exclusive, bool autoDelete, IDictionary<string, object> arguments)
        {
            QueueName = queueName;
            Durable = durable;
            Exclusive = exclusive;
            AutoDelete = autoDelete;
            Arguments = arguments;
        }

    }
}
