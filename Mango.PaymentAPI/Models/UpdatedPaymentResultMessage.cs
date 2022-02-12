using Mango.MessageBus;

namespace Mango.PaymentAPI.Models
{
    public class UpdatedPaymentResultMessage : BaseMessage
    {
        public int OrderId { get; set; }
        public bool Status { get; set; }
        public string Email { get; set; }
    }
}