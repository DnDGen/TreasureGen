using EquipmentGen.Selectors;
using EquipmentGen.Selectors.Interfaces;
using Ninject.Modules;

namespace EquipmentGen.Bootstrap.Modules
{
    public class SelectorsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPercentileResultProvider>().To<PercentileResultProvider>().InSingletonScope();
            Bind<ISpecialAbilityDataProvider>().To<SpecialAbilityDataProvider>().InSingletonScope();
            Bind<ITypeAndAmountPercentileResultProvider>().To<TypeAndAmountPercentileResultProvider>();
            Bind<IAttributesProvider>().To<AttributesProvider>().InSingletonScope();
        }
    }
}