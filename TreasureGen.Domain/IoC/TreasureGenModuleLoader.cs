using Ninject;
using TreasureGen.Domain.IoC.Modules;

namespace TreasureGen.Domain.IoC
{
    public class TreasureGenModuleLoader
    {
        public void LoadModules(IKernel kernel)
        {
            kernel.Load<GeneratorsModule>();
            kernel.Load<SelectorsModule>();
            kernel.Load<TablesModule>();
        }
    }
}