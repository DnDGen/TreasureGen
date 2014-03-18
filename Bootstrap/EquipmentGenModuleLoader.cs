using Ninject;

namespace EquipmentGen.Bootstrap
{
    public class EquipmentGenModuleLoader
    {
        public void LoadModules(IKernel kernel)
        {
            kernel.Load<MapperModule>();
            kernel.Load<GeneratorModule>();
            kernel.Load<SelectorModule>();
        }
    }
}