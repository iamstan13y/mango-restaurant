using AutoMapper;
using Azure.Messaging.ServiceBus;
using Mango.OrderAPI.Models;
using Mango.OrderAPI.Models.Repository;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mango.OrderAPI.Messages
{
    public class AzureServiceBusConsumer : IAzureServiceBusConsumer
    {
        private readonly string serviceBusConnectionString;
        private readonly string subscription;
        private readonly string topic;
        private readonly OrderRepository _orderRepository;
        private readonly IMapper _mapper;

        private ServiceBusProcessor checkoutProcessor;

        private readonly IConfiguration _configuration;
        public AzureServiceBusConsumer(OrderRepository orderRepository, IMapper mapper, IConfiguration configuration)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _configuration = configuration;

            serviceBusConnectionString = _configuration.GetValue<string>("ServiceBusConnectionString");
            subscription = _configuration.GetValue<string>("Subscription");
            topic = _configuration.GetValue<string>("Topic");

            var client = new ServiceBusClient(serviceBusConnectionString);
            checkoutProcessor = client.CreateProcessor(topic, subscription);
        }

        private async Task OnCheckOutMessageReceived(ProcessMessageEventArgs args)
        {
            var messsage = args.Message;
            var body = Encoding.UTF8.GetString(messsage.Body);

            CheckoutHeaderDto checkoutHeaderDto = JsonConvert.DeserializeObject<CheckoutHeaderDto>(body);

            var orderHeader = new OrderHeader()
            {
                CardNumber = checkoutHeaderDto.CardNumber,
                CartTotalItems = checkoutHeaderDto.CartTotalItems,
                CouponCode = checkoutHeaderDto.CouponCode,
                CVV = checkoutHeaderDto.CVV,
                DiscountTotal = checkoutHeaderDto.DiscountTotal,
                Email = checkoutHeaderDto.Email,
                ExpiryMonthYear = checkoutHeaderDto.ExpiryMonthYear,
                FirstName = checkoutHeaderDto.FirstName,
                LastName = checkoutHeaderDto.LastName,
                OrderTotal = checkoutHeaderDto.OrderTotal,
                PaymentStatus = false,
                Phone = checkoutHeaderDto.Phone,
                PickupDate = checkoutHeaderDto.PickupDate,
                UserId = checkoutHeaderDto.UserId,
                OrderTime = DateTime.Now,
                OrderDetails = new()
            };


            foreach (var detailList in checkoutHeaderDto.CartDetails)
            {
                OrderDetails orderDetails = new()
                {
                    ProductId = detailList.ProductId,
                    ProductName = detailList.Product.Name,
                    ProductPrice = detailList.Product.Price,
                    Count = detailList.Count
                };

                orderHeader.CartTotalItems += detailList.Count;
                orderHeader.OrderDetails.Add(orderDetails);
            }

            await _orderRepository.AddOrder(orderHeader);
        }

        public async Task Start()
        {
            checkoutProcessor.ProcessMessageAsync += OnCheckOutMessageReceived;
            checkoutProcessor.ProcessErrorAsync += ErrorHandler;
            await checkoutProcessor.StartProcessingAsync();
        }

        public async Task Stop()
        {
            await checkoutProcessor.StopProcessingAsync();
            await checkoutProcessor.DisposeAsync();
        }

        Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }
    }
}
