using AutoMapper;
using Mango.OrderAPI.Messages;
using Mango.OrderAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.OrderAPI.Utility
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<OrderHeader, CheckoutHeaderDto>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
