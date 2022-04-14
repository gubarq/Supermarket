using AutoMapper;
using Supermarket.Core.DtoObjects;
using Supermarket.Database.Entities.Base;

namespace Supermarket.Core.Mappers.Interfaces
{
    public interface IMappingProvider<TInput, TResult>
        where TInput : BaseEntity
        where TResult : BaseDto
    {
        void CreateMap(IMapperConfigurationExpression cfg);
    }
}
