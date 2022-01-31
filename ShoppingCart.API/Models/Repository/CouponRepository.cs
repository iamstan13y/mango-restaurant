using ShoppingCart.API.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.API.Models.Repository
{
    public class CouponRepository : ICouponRepository
    {
        public Task<CouponDto> GetCoupon(string couponName)
        {

        }
    }
}
