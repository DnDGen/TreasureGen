using D20Dice;
using EquipmentGen.Core.Generation.Factories;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Providers;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using Ninject.Modules;

namespace EquipmentGen.Bootstrap
{
    public class CoreModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITreasureFactory>().To<TreasureFactory>();
            Bind<ICoinFactory>().To<CoinFactory>();
            Bind<ICoinProvider>().To<CoinProvider>();
            Bind<IDice>().ToMethod(c => DiceFactory.Create()).InSingletonScope();
        }
    }
}