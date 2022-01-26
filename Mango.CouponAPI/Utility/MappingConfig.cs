using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.CouponAPI.Utility
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                //config.CreateMap<ProductDto, Product>().ReverseMap();
                //config.CreateMap<CartHeaderDto, CartHeader>().ReverseMap();
                //config.CreateMap<CartDto, Cart>().ReverseMap();
                //config.CreateMap<CartDetailsDto, CartDetails>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
