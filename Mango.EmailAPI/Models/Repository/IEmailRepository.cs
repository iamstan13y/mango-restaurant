using Mango.EmailAPI.Messages;
using System.Threading.Tasks;

namespace Mango.EmailAPI.Models.Repository
{
    public interface IEmailRepository
    {
        Task SendAndLogEmail(UpdatePaymentResultMessage message);
    }
}