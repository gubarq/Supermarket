using AutoMapper;
using Supermarket.Core.Mappers.Interfaces;
using Supermarket.Core.Services.ActionServices.Interfaces;
using Supermarket.Shared.Constants;
using System.Reflection;

namespace Supermarket.Core.Services.ActionServices
{
    public class DtoMappingService : IDtoMappingService
    {
        protected IMapper _mapper { get; init; }

        public DtoMappingService()
        {
            _mapper = new MapperConfiguration(CreateMaps).CreateMapper();
        }

        public TResult Map<TInput, TResult>(TInput input)
            => _mapper.Map<TInput, TResult>(input);

        private void CreateMaps(IMapperConfigurationExpression cfg)
        {
            var mappers = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace == Reflection.MapperNamespace).ToList();
            var genericTypeMappingProviderType = typeof(IMappingProvider<,>).GetGenericTypeDefinition();
            var createMappingMethod = genericTypeMappingProviderType.GetMethod("CreateMap");

            foreach (var mapper in mappers.Where(m => m.IsPublic))
            {
                var mapperObject = Activator.CreateInstance(mapper) as dynamic;

                if (mapperObject is not null)
                {
                    mapperObject.CreateMap(cfg);
                }
            }
        }
    }
}
