using System.Threading.Tasks;

namespace Mango.PaymentAPI.Messages
{
    public interface IAzureServiceBusConsumer
    {
        Task Start();
        Task Stop();
    }
}
