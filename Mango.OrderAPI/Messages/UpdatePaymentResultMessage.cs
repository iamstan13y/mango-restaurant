namespace Mango.OrderAPI.Messages
{
    public class UpdatePaymentResultMessage
    {
        public int OrderId { get; set; }
        public bool Status { get; set; }
        public string Email { get; set; }
    }
}