using AutoMapper;
using Mango.CouponAPI.Models.Data;
using Mango.CouponAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.CouponAPI.Models.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CouponRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CouponDto> GetCouponByCode(string couponCode)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(u => u.CouponCode == couponCode);

            return _mapper.Map<CouponDto>(coupon);
        }
    }
}
