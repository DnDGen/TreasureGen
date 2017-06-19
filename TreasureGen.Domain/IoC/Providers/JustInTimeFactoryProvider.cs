using Ninject.Activation;
using TreasureGen.Domain.Generators.Factories;

namespace TreasureGen.Domain.IoC.Providers
{
    class JustInTimeFactoryProvider : Provider<JustInTimeFactory>
    {
        protected override JustInTimeFactory CreateInstance(IContext context)
        {
            var factory = new NinjectJustInTimeFactory(context.Kernel);

            return factory;
        }
    }
}
