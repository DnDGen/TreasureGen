using EquipmentGen.Mappers.Attributes;
using EquipmentGen.Mappers.Interfaces;
using EquipmentGen.Tables.Interfaces;

namespace EquipmentGen.Bootstrap.Factories.Mappers
{
    public static class AttributesMapperFactory
    {
        public static IAttributesMapper CreateWith(IStreamLoader streamLoader)
        {
            IAttributesMapper mapper = new AttributesXmlMapper(streamLoader);
            mapper = new AttributesMapperCachingProxy(mapper);

            return mapper;
        }
    }
}