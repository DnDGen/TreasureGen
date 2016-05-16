using Ninject;
using Ninject.Activation;
using TreasureGen.Domain.Generators.Items.Mundane;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Domain.IoC.Providers
{
    class MundaneItemGeneratorProvider : Provider<MundaneItemGenerator>
    {
        private readonly string itemType;

        public MundaneItemGeneratorProvider(string itemType)
        {
            this.itemType = itemType;
        }

        protected override MundaneItemGenerator CreateInstance(IContext context)
        {
            var factory = context.Kernel.Get<IMundaneItemGeneratorFactory>();
            return factory.CreateGeneratorOf(itemType);
        }
    }
}
