using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.API.Models
{
    public class CartHeader
    {
        [Key]
        public int CartHeaderId { get; set; }
        public string UserId { get; set; }
        public string CouponCode { get; set; }
    }
}
