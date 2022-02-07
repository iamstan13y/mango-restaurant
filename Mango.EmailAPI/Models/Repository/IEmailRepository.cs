using Mango.EmailAPI.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.EmailAPI.Models.Repository
{
    public interface IEmailRepository
    {
        Task SendAndLogEmail(UpdatePaymentResultMessage message);
    }
}
