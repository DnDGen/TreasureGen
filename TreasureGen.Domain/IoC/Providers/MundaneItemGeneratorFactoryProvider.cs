using Ninject.Activation;
using TreasureGen.Domain.Generators.Items.Mundane;

namespace TreasureGen.Domain.IoC.Providers
{
    class MundaneItemGeneratorFactoryProvider : Provider<NinjectMundaneItemGeneratorRuntimeFactory>
    {
        protected override NinjectMundaneItemGeneratorRuntimeFactory CreateInstance(IContext context)
        {
            var factory = new NinjectMundaneItemGeneratorRuntimeFactory(context.Kernel);

            return factory;
        }
    }
}
