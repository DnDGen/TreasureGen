using EquipmentGen.Mappers;
using EquipmentGen.Mappers.Interfaces;
using Ninject.Modules;

namespace EquipmentGen.Bootstrap.Modules
{
    public class MappersModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPercentileXmlParser>().To<PercentileXmlParser>();
            Bind<ISpecialAbilityDataXmlParser>().To<SpecialAbilityDataXmlParser>();
            Bind<IAttributesMapper>().To<AttributesXmlParser>();
        }
    }
}