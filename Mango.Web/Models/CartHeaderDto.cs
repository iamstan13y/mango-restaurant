using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Web.Models
{
    public class CartHeaderDto
    {
        public int CartHeaderId { get; set; }
        public string UserId { get; set; }
        public string CouponCode { get; set; }
        public double OrderTotal { get; set; }
    }
}
