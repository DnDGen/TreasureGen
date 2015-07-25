using Ninject;
using TreasureGen.Mappers;
using TreasureGen.Mappers.Domain.Attributes;
using TreasureGen.Tables;

namespace TreasureGen.Bootstrap.Factories.Mappers
{
    public static class AttributesMapperFactory
    {
        public static IAttributesMapper CreateWith(IKernel kernel)
        {
            var streamLoader = kernel.Get<IStreamLoader>();

            IAttributesMapper mapper = new AttributesXmlMapper(streamLoader);
            mapper = new AttributesMapperCachingProxy(mapper);

            return mapper;
        }
    }
}