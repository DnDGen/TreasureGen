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
            Bind<IAlchemicalItemFactory>().To<AlchemicalItemFactory>();
            Bind<ICoinFactory>().To<CoinFactory>();
            Bind<IDice>().ToMethod(c => DiceFactory.Create()).InSingletonScope();
            Bind<IGearFactoryFactory>().To<GearFactoryFactory>();
            Bind<IGoodPercentileResultProvider>().To<GoodPercentileResultProvider>();
            Bind<IGoodsFactory>().To<GoodsFactory>();
            Bind<IItemsFactory>().To<ItemsFactory>();
            Bind<IPercentileResultProvider>().To<PercentileResultProvider>().InSingletonScope();
            Bind<IPercentileXmlParser>().To<PercentileXmlParser>();
            Bind<IPowerFactoryFactory>().To<PowerFactoryFactory>();
            Bind<IStreamLoader>().To<EmbeddedResourceStreamLoader>();
            Bind<IToolFactory>().To<ToolFactory>();
            Bind<ITreasureFactory>().To<TreasureFactory>();
            Bind<ITypeAndAmountPercentileResultProvider>().To<TypeAndAmountPercentileResultProvider>();
        }
    }
}