using AutoMapper;

namespace Supermarket.Core.Mappers.Interfaces
{
    public interface IMappingProvider<TInput, TResult>
    {
        void CreateMap(IMapperConfigurationExpression cfg);
    }
}
