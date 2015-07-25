using Ninject.Modules;
using TreasureGen.Bootstrap.Factories.Selectors;
using TreasureGen.Selectors;
using TreasureGen.Selectors.Domain;

namespace TreasureGen.Bootstrap.Modules
{
    public class SelectorsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISpecialAbilityAttributesSelector>().To<SpecialAbilityAttributesSelector>();
            Bind<IIntelligenceAttributesSelector>().To<IntelligenceAttributesSelector>();
            Bind<IRangeAttributesSelector>().To<RangeAttributesSelector>();
            Bind<ITypeAndAmountPercentileSelector>().To<TypeAndAmountPercentileSelector>();
            Bind<IAttributesSelector>().To<AttributesSelector>();
            Bind<IBooleanPercentileSelector>().To<BooleanPercentileSelector>();

            Bind<IPercentileSelector>().ToMethod(c => PercentileSelectorFactory.CreateWith(c.Kernel));
        }
    }
}