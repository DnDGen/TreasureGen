using Ninject;

namespace EquipmentGen.Bootstrap
{
    public class EquipmentGenModuleLoader
    {
        public void LoadModules(IKernel kernel)
        {
            kernel.Load<CoreModule>();
        }
    }
}