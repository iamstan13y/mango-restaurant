using AutoMapper;
using Mango.CouponAPI.Models;
using Mango.CouponAPI.Models.Dto;

namespace Mango.CouponAPI.Utility
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
