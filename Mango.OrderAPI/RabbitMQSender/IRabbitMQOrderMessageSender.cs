using Mango.MessageBus;

namespace Mango.OrderAPI.RabbitMQSender
{
    public interface IRabbitMQOrderMessageSender
    {
        void SendMessage(BaseMessage baseMessage, string queueName);
    }
}