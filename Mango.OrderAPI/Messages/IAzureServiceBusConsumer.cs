using System.Threading.Tasks;

namespace Mango.OrderAPI.Messages
{
    public interface IAzureServiceBusConsumer
    {
        Task Start();
        Task Stop();
    }
}
