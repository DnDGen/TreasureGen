using Ninject.Activation;
using TreasureGen.Domain.Generators.Items.Magical;

namespace TreasureGen.Domain.IoC.Providers
{
    class MagicalItemGeneratorFactoryProvider : Provider<NinjectMagicalItemGeneratorRuntimeFactory>
    {
        protected override NinjectMagicalItemGeneratorRuntimeFactory CreateInstance(IContext context)
        {
            var factory = new NinjectMagicalItemGeneratorRuntimeFactory(context.Kernel);

            return factory;
        }
    }
}
