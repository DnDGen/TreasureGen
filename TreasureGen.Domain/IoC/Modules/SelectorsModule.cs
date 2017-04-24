using Ninject.Modules;
using TreasureGen.Domain.Selectors.Collections;
using TreasureGen.Domain.Selectors.Percentiles;

namespace TreasureGen.Domain.IoC.Modules
{
    internal class SelectorsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISpecialAbilityDataSelector>().To<SpecialAbilityDataSelector>();
            Bind<IIntelligenceDataSelector>().To<IntelligenceDataSelector>();
            Bind<IRangeDataSelector>().To<RangeDataSelector>();
            Bind<ITypeAndAmountPercentileSelector>().To<TypeAndAmountPercentileSelector>();
            Bind<ICollectionsSelector>().To<CollectionsSelector>();
            Bind<IBooleanPercentileSelector>().To<BooleanPercentileSelector>();
            Bind<IArmorDataSelector>().To<ArmorDataSelector>();

            Bind<IPercentileSelector>().To<PercentileSelector>().WhenInjectedInto<ReplacePercentileSelectorDecorator>();
            Bind<IPercentileSelector>().To<ReplacePercentileSelectorDecorator>();
        }
    }
}