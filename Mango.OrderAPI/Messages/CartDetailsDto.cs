using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.OrderAPI.Messages
{
    public class CartDetailsDto
    {
        public int CartDetailsId { get; set; }
        public int CartHeaderId { get; set; }
        public int ProductId { get; set; }
        public virtual ProductDto Product { get; set; }
        public int Count { get; set; }
    }
}
