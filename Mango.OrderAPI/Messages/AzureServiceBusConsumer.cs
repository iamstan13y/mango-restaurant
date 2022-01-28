using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mango.OrderAPI.Messages
{
    public class AzureServiceBusConsumer
    {
        private async Task OnCheckOutMessageReceived(ProcessMessageEventArgs args)
        {
            var messsage = args.Message;
            var body = Encoding.UTF8.GetString(messsage.Body);

            CheckoutHeaderDto checkoutHeaderDto = JsonConvert.DeserializeObject<CheckoutHeaderDto>(body);
        }
    }
}
