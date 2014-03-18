using EquipmentGen.Core.Generation.Xml.Parsers;
using EquipmentGen.Core.Generation.Xml.Parsers.Interfaces;
using Ninject.Modules;

namespace EquipmentGen.Bootstrap
{
    public class MapperModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPercentileXmlParser>().To<PercentileXmlParser>();
            Bind<ISpecialAbilityDataXmlParser>().To<SpecialAbilityDataXmlParser>();
            Bind<IStreamLoader>().To<EmbeddedResourceStreamLoader>();
            Bind<IAttributesXmlParser>().To<AttributesXmlParser>();
        }
    }
}