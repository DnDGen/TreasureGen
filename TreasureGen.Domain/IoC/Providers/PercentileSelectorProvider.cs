using Ninject;
using Ninject.Activation;
using TreasureGen.Domain.Selectors.Attributes;
using TreasureGen.Domain.Selectors.Percentiles;

namespace TreasureGen.Domain.IoC.Providers
{
    class PercentileSelectorProvider : Provider<IPercentileSelector>
    {
        protected override IPercentileSelector CreateInstance(IContext context)
        {
            IPercentileSelector selector = context.Kernel.Get<PercentileSelector>();

            var attributesSelector = context.Kernel.Get<IAttributesSelector>();
            selector = new ReplacePercentileSelectorDecorator(selector, attributesSelector);

            return selector;
        }
    }
}