using EquipmentGen.Mappers.Interfaces;
using EquipmentGen.Mappers.SpecialAbilityData;
using EquipmentGen.Tables.Interfaces;

namespace EquipmentGen.Bootstrap.Factories.Mappers
{
    public static class SpecialAbilityDataMapperFactory
    {
        public static ISpecialAbilityDataMapper CreateWith(IStreamLoader streamLoader)
        {
            ISpecialAbilityDataMapper mapper = new SpecialAbilityDataXmlMapper(streamLoader);
            mapper = new SpecialAbilityDataMapperCachingProxy(mapper);

            return mapper;
        }
    }
}