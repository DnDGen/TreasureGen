using Ninject.Modules;
using TreasureGen.Tables;
using TreasureGen.Tables.Domain;

namespace TreasureGen.Bootstrap.Modules
{
    public class TablesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IStreamLoader>().To<EmbeddedResourceStreamLoader>();
        }
    }
}