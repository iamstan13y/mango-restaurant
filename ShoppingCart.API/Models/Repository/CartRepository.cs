using ShoppingCart.API.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.API.Models.Repository
{
    public class CartRepository : ICartRepository
    {
        public Task<bool> ClearCart(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<CartDto> CreateUpdateCart(CartDto cartDto)
        {
            throw new NotImplementedException();
        }

        public Task<CartDto> GetCartByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveFromCart(int cartDetailsId)
        {
            throw new NotImplementedException();
        }
    }
}
