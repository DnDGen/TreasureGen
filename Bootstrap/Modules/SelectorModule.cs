using EquipmentGen.Core.Generation.Providers;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using Ninject.Modules;

namespace EquipmentGen.Bootstrap
{
    public class SelectorModule : NinjectModule
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