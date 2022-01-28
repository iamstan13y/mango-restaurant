using AutoMapper;
using Mango.OrderAPI.Messages;
using Mango.OrderAPI.Models;

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
