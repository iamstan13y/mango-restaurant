using System.Threading.Tasks;

namespace Mango.OrderAPI.Models.Repository
{
    public interface IOrderRepository
    {
        Task<bool> AddOrder(OrderHeader orderHeader);

        Task UpdateOrderPaymentStatus(int orderHeaderId, bool paid);
    }
}