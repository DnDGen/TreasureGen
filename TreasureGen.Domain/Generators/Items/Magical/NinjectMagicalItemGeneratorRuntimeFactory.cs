using Ninject;
using TreasureGen.Items.Magical;

namespace TreasureGen.Domain.Generators.Items.Magical
{
    internal class NinjectMagicalItemGeneratorRuntimeFactory : IMagicalItemGeneratorRuntimeFactory
    {
        private readonly IKernel kernel;

        public NinjectMagicalItemGeneratorRuntimeFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public MagicalItemGenerator CreateGeneratorOf(string itemType)
        {
            return kernel.Get<MagicalItemGenerator>(itemType);
        }
    }
}