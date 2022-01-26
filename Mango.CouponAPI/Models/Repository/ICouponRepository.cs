using Mango.CouponAPI.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.CouponAPI.Models.Repository
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCouponByCode(string couponCode);
    }
}
