using EquipmentGen.Selectors;
using EquipmentGen.Selectors.Interfaces;
using Ninject.Modules;

namespace EquipmentGen.Bootstrap.Modules
{
    public class SelectorsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPercentileSelector>().To<PercentileSelector>();
            Bind<ISpecialAbilityAttributesSelector>().To<SpecialAbilityAttributesSelector>();
            Bind<IIntelligenceAttributesSelector>().To<IntelligenceAttributesSelector>();
            Bind<IRangeAttributesSelector>().To<RangeAttributesSelector>();
            Bind<ITypeAndAmountPercentileSelector>().To<TypeAndAmountPercentileSelector>();
            Bind<IAttributesSelector>().To<AttributesSelector>();
            Bind<IBooleanPercentileSelector>().To<BooleanPercentileSelector>();
        }
    }
}