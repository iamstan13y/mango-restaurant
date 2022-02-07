using Mango.EmailAPI.Messages;
using Mango.EmailAPI.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.EmailAPI.Models.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly DbContextOptions<ApplicationDbContext> _context;

        public EmailRepository(DbContextOptions<ApplicationDbContext> context)
        {
            _context = context;
        }
         
        public async Task SendAndLogEmail(UpdatePaymentResultMessage message)
        {
            var emailLog = new EmailLog()
            {
                SentDate = DateTime.Now,
                Email = message.Email,
                Log = $"Order - {message.OrderId} has been created successfully!"
            };

            await using var _db = new ApplicationDbContext(_context);
            _db.EmailLogs.Add(emailLog);
            await _db.SaveChangesAsync();
        }
    }
}
