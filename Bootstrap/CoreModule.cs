using D20Dice;
using EquipmentGen.Core.Generation.Factories;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators;
using EquipmentGen.Core.Generation.Generators.Interfaces;
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
            Bind<IAlchemicalItemGenerator>().To<AlchemicalItemGenerator>();
            Bind<ICoinGenerator>().To<CoinGenerator>();
            Bind<IDice>().ToMethod(c => DiceFactory.Create()).InSingletonScope();
            Bind<IGearGeneratorFactory>().To<GearGeneratorFactory>();
            Bind<IGoodPercentileResultProvider>().To<GoodPercentileResultProvider>();
            Bind<IGoodsGenerator>().To<GoodsGenerator>();
            Bind<IItemsGenerator>().To<ItemsGenerator>();
            Bind<IPercentileResultProvider>().To<PercentileResultProvider>().InSingletonScope();
            Bind<IPercentileXmlParser>().To<PercentileXmlParser>();
            Bind<IPowerItemGeneratorFactory>().To<PowerItemGeneratorFactory>();
            Bind<IStreamLoader>().To<EmbeddedResourceStreamLoader>();
            Bind<IToolGenerator>().To<ToolGenerator>();
            Bind<ITreasureGenerator>().To<TreasureGenerator>();
            Bind<ITypeAndAmountPercentileResultProvider>().To<TypeAndAmountPercentileResultProvider>();
        }
    }
}