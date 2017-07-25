using DnDGen.Core.Tables;
using Ninject.Modules;
using TreasureGen.Domain.Tables;

namespace TreasureGen.Domain.IoC.Modules
{
    internal class TablesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<AssemblyLoader>().To<TreasureGenAssemblyLoader>();
        }
    }
}