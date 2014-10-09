using D20Dice;
using EquipmentGen.Bootstrap.Factories.Selectors;
using EquipmentGen.Mappers.Interfaces;
using EquipmentGen.Selectors;
using EquipmentGen.Selectors.Interfaces;
using Ninject;
using Ninject.Modules;

namespace EquipmentGen.Bootstrap.Modules
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

            Bind<IPercentileSelector>().ToMethod(c => PercentileSelectorFactory.CreateWith(c.Kernel.Get<IPercentileMapper>(),
                c.Kernel.Get<IDice>(), c.Kernel.Get<IAttributesSelector>()));
        }
    }
}