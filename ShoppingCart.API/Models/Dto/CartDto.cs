using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.API.Models.Dto
{
    public class CartDto
    {
        public CartHeaderDto CartHeader { get; set; }
        public IEnumerable<CartDetailsDto> CartDetails { get; set; }
    }
}
