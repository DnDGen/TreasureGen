using Ninject.Modules;
using TreasureGen.Domain.IoC.Providers;
using TreasureGen.Domain.Selectors.Attributes;
using TreasureGen.Domain.Selectors.Percentiles;

namespace TreasureGen.Domain.IoC.Modules
{
    internal class SelectorsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISpecialAbilityAttributesSelector>().To<SpecialAbilityAttributesSelector>();
            Bind<IIntelligenceAttributesSelector>().To<IntelligenceAttributesSelector>();
            Bind<IRangeAttributesSelector>().To<RangeAttributesSelector>();
            Bind<ITypeAndAmountPercentileSelector>().To<TypeAndAmountPercentileSelector>();
            Bind<IAttributesSelector>().To<AttributesSelector>();
            Bind<IBooleanPercentileSelector>().To<BooleanPercentileSelector>();

            Bind<IPercentileSelector>().ToProvider<PercentileSelectorProvider>();
        }
    }
}