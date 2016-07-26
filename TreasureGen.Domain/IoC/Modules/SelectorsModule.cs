using Ninject.Modules;
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
            Bind<ICollectionsSelector>().To<CollectionsSelector>();
            Bind<IBooleanPercentileSelector>().To<BooleanPercentileSelector>();

            Bind<IPercentileSelector>().To<PercentileSelector>().WhenInjectedInto<ReplacePercentileSelectorDecorator>();
            Bind<IPercentileSelector>().To<ReplacePercentileSelectorDecorator>();
        }
    }
}