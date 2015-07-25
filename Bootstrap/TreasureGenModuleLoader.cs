using Ninject;
using TreasureGen.Bootstrap.Modules;

namespace TreasureGen.Bootstrap
{
    public class TreasureGenModuleLoader
    {
        public void LoadModules(IKernel kernel)
        {
            kernel.Load<MappersModule>();
            kernel.Load<GeneratorsModule>();
            kernel.Load<SelectorsModule>();
            kernel.Load<TablesModule>();
        }
    }
}