namespace Core.Model
{
    public class Worker
    {
        public Queue Queue { get; private set; }
        public BasicPublish BasicPublish { get; private set; }

        public void Create(Queue queue, BasicPublish basicPublish)
        {
            Queue = queue;
            BasicPublish = basicPublish;
        }

        public Worker()
        {

        }
    }
}
