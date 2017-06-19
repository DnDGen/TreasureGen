using Ninject;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Domain.Generators.Items.Mundane
{
    internal class NinjectMundaneItemGeneratorRuntimeFactory : IMundaneItemGeneratorRuntimeFactory
    {
        private readonly IKernel kernel;

        public NinjectMundaneItemGeneratorRuntimeFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public MundaneItemGenerator CreateGeneratorOf(string itemType)
        {
            return kernel.Get<MundaneItemGenerator>(itemType);
        }
    }
}