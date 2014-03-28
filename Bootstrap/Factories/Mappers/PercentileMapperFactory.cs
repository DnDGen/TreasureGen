using EquipmentGen.Mappers.Interfaces;
using EquipmentGen.Mappers.Percentile;
using EquipmentGen.Tables.Interfaces;

namespace EquipmentGen.Bootstrap.Factories.Mappers
{
    public static class PercentileMapperFactory
    {
        public static IPercentileMapper CreateWith(IStreamLoader streamLoader)
        {
            IPercentileMapper mapper = new PercentileXmlMapper(streamLoader);
            mapper = new PercentileMapperCachingProxy(mapper);

            return mapper;
        }
    }
}