using EquipmentGen.Core.Generation.Xml.Parsers;
using EquipmentGen.Core.Generation.Xml.Parsers.Interfaces;
using Ninject.Modules;

namespace EquipmentGen.Bootstrap
{
    public class MappersModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPercentileXmlParser>().To<PercentileXmlParser>();
            Bind<ISpecialAbilityDataXmlParser>().To<SpecialAbilityDataXmlParser>();
            Bind<IAttributesXmlParser>().To<AttributesXmlParser>();
        }
    }
}