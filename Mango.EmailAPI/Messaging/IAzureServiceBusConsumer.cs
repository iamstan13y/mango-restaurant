using System.Threading.Tasks;

namespace Mango.EmailAPI.Messaging
{
    public interface IAzureServiceBusConsumer
    {
        Task Start();

        Task Stop();
    }
}