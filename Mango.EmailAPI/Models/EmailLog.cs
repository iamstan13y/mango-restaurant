using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.EmailAPI.Models
{
    public class EmailLog
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Log { get; set; }
        public DateTime SentDate { get; set; }
    }
}
