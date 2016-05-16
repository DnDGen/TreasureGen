using Ninject;
using Ninject.Activation;
using TreasureGen.Domain.Generators.Items.Magical;
using TreasureGen.Items.Magical;

namespace TreasureGen.Domain.IoC.Providers
{
    class MagicalItemGeneratorProvider : Provider<MagicalItemGenerator>
    {
        private readonly string itemType;

        public MagicalItemGeneratorProvider(string itemType)
        {
            this.itemType = itemType;
        }

        protected override MagicalItemGenerator CreateInstance(IContext context)
        {
            var factory = context.Kernel.Get<IMagicalItemGeneratorFactory>();
            return factory.CreateGeneratorOf(itemType);
        }
    }
}
