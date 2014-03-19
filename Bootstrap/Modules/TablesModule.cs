using EquipmentGen.Core.Generation.Xml.Parsers;
using EquipmentGen.Core.Generation.Xml.Parsers.Interfaces;
using Ninject.Modules;

namespace EquipmentGen.Bootstrap
{
    public class TablesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IStreamLoader>().To<EmbeddedResourceStreamLoader>();
        }
    }
}