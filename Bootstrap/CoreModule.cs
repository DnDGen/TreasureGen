using D20Dice;
using EquipmentGen.Core.Generation.Factories;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Providers;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using EquipmentGen.Core.Generation.Xml.Parsers;
using EquipmentGen.Core.Generation.Xml.Parsers.Interfaces;
using Ninject.Modules;

namespace EquipmentGen.Bootstrap
{
    public class CoreModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICoinFactory>().To<CoinFactory>();
            Bind<ICoinPercentileResultProvider>().To<CoinPercentileResultProvider>();
            Bind<IDice>().ToMethod(c => DiceFactory.Create()).InSingletonScope();
            Bind<IGoodDescriptionProvider>().To<GoodDescriptionProvider>();
            Bind<IGoodPercentileResultProvider>().To<GoodPercentileResultProvider>();
            Bind<IGoodsFactory>().To<GoodsFactory>();
            Bind<IPercentileResultProvider>().To<PercentileResultProvider>().InSingletonScope();
            Bind<IPercentileXmlParser>().To<PercentileXmlParser>();
            Bind<IStreamLoader>().To<EmbeddedResourceStreamLoader>();
            Bind<ITreasureFactory>().To<TreasureFactory>();
        }
    }
}