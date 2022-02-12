using AutoMapper;
using Mango.ProductAPI.Data.Models;
using Mango.ProductAPI.Data.Models.Dto;

namespace Mango.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}