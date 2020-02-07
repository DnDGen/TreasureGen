using DnDGen.TreasureGen.Selectors.Collections;
using DnDGen.TreasureGen.Selectors.Percentiles;
using Ninject.Modules;

namespace DnDGen.TreasureGen.IoC.Modules
{
    internal class SelectorsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IIntelligenceDataSelector>().To<IntelligenceDataSelector>();
            Bind<IRangeDataSelector>().To<RangeDataSelector>();
            Bind<IArmorDataSelector>().To<ArmorDataSelector>();
            Bind<IWeaponDataSelector>().To<WeaponDataSelector>();
            Bind<ITreasurePercentileSelector>().To<PercentileSelectorStringReplacementDecorator>();
            Bind<IReplacementSelector>().To<ReplacementSelector>();

            Bind<ITypeAndAmountPercentileSelector>().To<TypeAndAmountPercentileSelector>().WhenInjectedInto<TypeAndAmountPercentileSelectorEventDecorator>();
            Bind<ITypeAndAmountPercentileSelector>().To<TypeAndAmountPercentileSelectorEventDecorator>();

            Bind<ISpecialAbilityDataSelector>().To<SpecialAbilityDataSelector>().WhenInjectedInto<SpecialAbilityDataSelectorEventDecorator>();
            Bind<ISpecialAbilityDataSelector>().To<SpecialAbilityDataSelectorEventDecorator>();
        }
    }
}