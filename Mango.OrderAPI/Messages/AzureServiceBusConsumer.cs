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
    public class AzureServiceBusConsumer
    {
        private readonly string serviceBusConnectionString;
        private readonly string subscription;
        private readonly string topic;
        private readonly OrderRepository _orderRepository;
        private readonly IMapper _mapper;

        private readonly IConfiguration _configuration;
        public AzureServiceBusConsumer(OrderRepository orderRepository, IMapper mapper, IConfiguration configuration)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _configuration = configuration;

            serviceBusConnectionString = _configuration.GetValue<string>("ServiceBusConnectionString");
            subscription = _configuration.GetValue<string>("Subscription");
            topic = _configuration.GetValue<string>("Topic");
        }

        private async Task OnCheckOutMessageReceived(ProcessMessageEventArgs args)
        {
            var messsage = args.Message;
            var body = Encoding.UTF8.GetString(messsage.Body);

            CheckoutHeaderDto checkoutHeaderDto = JsonConvert.DeserializeObject<CheckoutHeaderDto>(body);

            var orderHeader = _mapper.Map<OrderHeader>(checkoutHeaderDto);
            orderHeader.OrderTime = DateTime.Now;
            orderHeader.OrderDetails = new();

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
    }
}
