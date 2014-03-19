using EquipmentGen.Selectors;
using EquipmentGen.Selectors.Interfaces;
using Ninject.Modules;

namespace EquipmentGen.Bootstrap.Modules
{
    public class SelectorsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPercentileSelector>().To<PercentileSelector>().InSingletonScope();
            Bind<ISpecialAbilityDataSelector>().To<SpecialAbilityDataSelector>().InSingletonScope();
            Bind<ITypeAndAmountPercentileSelector>().To<TypeAndAmountPercentileSelector>();
            Bind<IAttributesSelector>().To<AttributesSelector>().InSingletonScope();
        }
    }
}