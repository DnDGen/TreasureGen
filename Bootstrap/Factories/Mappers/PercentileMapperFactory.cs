using Ninject;
using TreasureGen.Mappers;
using TreasureGen.Mappers.Domain.Percentile;
using TreasureGen.Tables;

namespace TreasureGen.Bootstrap.Factories.Mappers
{
    public static class PercentileMapperFactory
    {
        public static IPercentileMapper CreateWith(IKernel kernel)
        {
            var streamLoader = kernel.Get<IStreamLoader>();

            IPercentileMapper mapper = new PercentileXmlMapper(streamLoader);
            mapper = new PercentileMapperCachingProxy(mapper);

            return mapper;
        }
    }
}