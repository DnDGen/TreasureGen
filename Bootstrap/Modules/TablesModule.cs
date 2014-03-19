using EquipmentGen.Tables;
using EquipmentGen.Tables.Interfaces;
using Ninject.Modules;

namespace EquipmentGen.Bootstrap.Modules
{
    public class TablesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IStreamLoader>().To<EmbeddedResourceStreamLoader>();
        }
    }
}