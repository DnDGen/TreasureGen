using EquipmentGen.Bootstrap.Modules;
using Ninject;

namespace EquipmentGen.Bootstrap
{
    public class EquipmentGenModuleLoader
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