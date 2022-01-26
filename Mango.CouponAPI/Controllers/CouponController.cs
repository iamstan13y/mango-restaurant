using Mango.CouponAPI.Models.Dto;
using Mango.CouponAPI.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        public readonly ICouponRepository _couponRepository;
        public readonly ResponseDto response;

        public CouponController(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
            response = new();
        }

        [HttpGet("{code}")]
        public async Task<object> GetDiscountCode(string code)
        {
            try
            {
                var coupon = await _couponRepository.GetCouponByCode(code);
                response.Result = coupon;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return response;
        }
    }
}
