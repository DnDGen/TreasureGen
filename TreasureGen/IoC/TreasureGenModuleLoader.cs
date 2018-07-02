using Ninject;
using TreasureGen.IoC.Modules;

namespace TreasureGen.IoC
{
    public class TreasureGenModuleLoader
    {
        public void LoadModules(IKernel kernel)
        {
            kernel.Load<GeneratorsModule>();
            kernel.Load<SelectorsModule>();
        }
    }
}