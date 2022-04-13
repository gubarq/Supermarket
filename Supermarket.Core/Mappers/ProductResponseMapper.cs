using AutoMapper;
using Supermarket.Core.DtoObjects.Api.Product;
using Supermarket.Core.Mappers.Interfaces;
using Supermarket.Database.Entities;

namespace Supermarket.Core.Mappers
{
    public class ProductResponseMapper : IMappingProvider<Product, ProductResponseDto>
    {
        public void CreateMap(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Product, ProductResponseDto>()
                .ForMember(d => d.LowQuantity, o => o.MapFrom(s => s.Quantity <= 10))
                .ForMember(d => d.Quantity, o => o.MapFrom(s => s.Quantity <= 10 ? s.Quantity : -1));
        }
    }
}
