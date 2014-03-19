using EquipmentGen.Mappers;
using EquipmentGen.Mappers.Interfaces;
using Ninject.Modules;

namespace EquipmentGen.Bootstrap.Modules
{
    public class MappersModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPercentileMapper>().To<PercentileXmlMapper>();
            Bind<ISpecialAbilityDataMapper>().To<SpecialAbilityDataXmlMapper>();
            Bind<IAttributesMapper>().To<AttributesXmlMapper>();
        }
    }
}