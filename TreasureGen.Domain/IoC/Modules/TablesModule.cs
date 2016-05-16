using Ninject.Modules;
using TreasureGen.Domain.Tables;

namespace TreasureGen.Domain.IoC.Modules
{
    internal class TablesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IStreamLoader>().To<EmbeddedResourceStreamLoader>();
        }
    }
}