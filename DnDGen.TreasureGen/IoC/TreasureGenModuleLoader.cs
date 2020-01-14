using DnDGen.TreasureGen.IoC.Modules;
using Ninject;

namespace DnDGen.TreasureGen.IoC
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