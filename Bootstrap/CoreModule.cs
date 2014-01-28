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
            Bind<IAmmunitionGenerator>().To<AmmunitionGenerator>();
            Bind<ICoinGenerator>().To<CoinGenerator>();
            Bind<IDice>().ToMethod(c => DiceFactory.Create()).InSingletonScope();
            Bind<IGearSpecialAbilitiesGenerator>().To<GearSpecialAbilitiesGenerator>();
            Bind<IGearTypesProvider>().To<GearTypesProvider>().InSingletonScope();
            Bind<IGoodPercentileResultProvider>().To<GoodPercentileResultProvider>();
            Bind<IGoodsGenerator>().To<GoodsGenerator>();
            Bind<IItemsGenerator>().To<ItemsGenerator>();
            Bind<IMagicalItemGeneratorFactory>().To<MagicalItemGeneratorFactory>();
            Bind<IMaterialsProvider>().To<MaterialsProvider>();
            Bind<IMundaneGearGeneratorFactory>().To<MundaneGearGeneratorFactory>();
            Bind<IMundaneItemGenerator>().To<MundaneItemGenerator>();
            Bind<IPercentileResultProvider>().To<PercentileResultProvider>().InSingletonScope();
            Bind<IPercentileXmlParser>().To<PercentileXmlParser>();
            Bind<IPowerItemGenerator>().To<PowerItemGenerator>();
            Bind<IPowerGearGeneratorFactory>().To<PowerGearGeneratorFactory>();
            Bind<IStreamLoader>().To<EmbeddedResourceStreamLoader>();
            Bind<IToolGenerator>().To<ToolGenerator>();
            Bind<ITreasureGenerator>().To<TreasureGenerator>();
            Bind<ITypeAndAmountPercentileResultProvider>().To<TypeAndAmountPercentileResultProvider>();
            Bind<ITypesXmlParser>().To<TypesXmlParser>();
        }
    }
}