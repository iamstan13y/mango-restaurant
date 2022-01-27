using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.OrderAPI.Models.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public Task<bool> AddOrder(OrderHeader orderHeader)
        {

        }

        public Task UpdateOrderPaymentStatus(int orderHeaderId, bool paid)
        {

        }
    }
}
