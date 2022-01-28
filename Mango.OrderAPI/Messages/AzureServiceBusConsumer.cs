using AutoMapper;
using Azure.Messaging.ServiceBus;
using Mango.OrderAPI.Models;
using Mango.OrderAPI.Models.Repository;
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
        private readonly OrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public AzureServiceBusConsumer(OrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
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
