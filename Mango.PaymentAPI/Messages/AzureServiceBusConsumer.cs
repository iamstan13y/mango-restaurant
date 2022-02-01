using Azure.Messaging.ServiceBus;
using Mango.MessageBus;
using Mango.PaymentAPI.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PaymentProcessor;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Mango.PaymentAPI.Messages
{
    public class AzureServiceBusConsumer : IAzureServiceBusConsumer
    {
        private readonly string serviceBusConnectionString;
        private readonly string subscriptionPayment;
        private readonly string orderPaymentProcessTopic;
        private readonly string orderUpdatePaymentResultTopic;

        private readonly ServiceBusProcessor orderPaymentProcessor;
        private readonly IProcessPayment _processPayment;
        private readonly IConfiguration _configuration;
        private readonly IMessageBus _messageBus;

        public AzureServiceBusConsumer(IProcessPayment processPayment, IConfiguration configuration, IMessageBus messageBus)
        {
            _processPayment = processPayment;
            _configuration = configuration;
            _messageBus = messageBus;

            serviceBusConnectionString = _configuration.GetValue<string>("ServiceBusConnectionString");
            subscriptionPayment = _configuration.GetValue<string>("OrderPaymentProcessSubscription");
            orderPaymentProcessTopic = _configuration.GetValue<string>("OrderPaymentProcessTopic");
            orderUpdatePaymentResultTopic = _configuration.GetValue<string>("OrderUpdatePaymentResultTopic");

            var client = new ServiceBusClient(serviceBusConnectionString);
            orderPaymentProcessor = client.CreateProcessor(orderPaymentProcessTopic, subscriptionPayment);
        }

        private async Task ProcessPayments(ProcessMessageEventArgs args)
        {
            var messsage = args.Message;
            var body = Encoding.UTF8.GetString(messsage.Body);

            PaymentRequestMessage paymentRequestMessage = JsonConvert.DeserializeObject<PaymentRequestMessage>(body);

            var result = _processPayment.PaymentProcessor();

            UpdatedPaymentResultMessage updatePaymentResultMessage = new()
            {
                Status = result,
                OrderId = paymentRequestMessage.OrderId
            };

            try
            {
                await _messageBus.PublishMessage(updatePaymentResultMessage, orderUpdatePaymentResultTopic);
                await args.CompleteMessageAsync(args.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Start()
        {
            orderPaymentProcessor.ProcessMessageAsync += ProcessPayments;
            orderPaymentProcessor.ProcessErrorAsync += ErrorHandler;
            await orderPaymentProcessor.StartProcessingAsync();
        }

        public async Task Stop()
        {
            await orderPaymentProcessor.StopProcessingAsync();
            await orderPaymentProcessor.DisposeAsync();
        }

        private Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }
    }
}