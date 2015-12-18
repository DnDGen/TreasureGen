using Ninject;
using RollGen;
using TreasureGen.Mappers;
using TreasureGen.Selectors;
using TreasureGen.Selectors.Domain;
using TreasureGen.Selectors.Domain.Decorators;

namespace TreasureGen.Bootstrap.Factories.Selectors
{
    public static class PercentileSelectorFactory
    {
        public static IPercentileSelector CreateWith(IKernel kernel)
        {
            var percentileMapper = kernel.Get<IPercentileMapper>();
            var dice = kernel.Get<Dice>();
            var attributesSelector = kernel.Get<IAttributesSelector>();

            IPercentileSelector selector = new PercentileSelector(percentileMapper, dice);
            selector = new ReplacePercentileSelectorDecorator(selector, attributesSelector);

            return selector;
        }
    }
}