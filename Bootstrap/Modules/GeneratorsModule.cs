using D20Dice;
using EquipmentGen.Core.Generation.Factories;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject.Modules;

namespace EquipmentGen.Bootstrap
{
    public class GeneratorsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAlchemicalItemGenerator>().To<AlchemicalItemGenerator>();
            Bind<IAmmunitionGenerator>().To<AmmunitionGenerator>();
            Bind<IChargesGenerator>().To<ChargesGenerator>();
            Bind<ICoinGenerator>().To<CoinGenerator>();
            Bind<ICurseGenerator>().To<CurseGenerator>();
            Bind<IDice>().ToMethod(c => DiceFactory.Create()).InSingletonScope();
            Bind<IGoodsGenerator>().To<GoodsGenerator>();
            Bind<IIntelligenceGenerator>().To<IntelligenceGenerator>();
            Bind<IItemsGenerator>().To<ItemsGenerator>();
            Bind<IMagicalGearGeneratorFactory>().To<MagicalGearGeneratorFactory>();
            Bind<IMagicalItemGeneratorFactory>().To<MagicalItemGeneratorFactory>();
            Bind<IMagicalItemTraitsGenerator>().To<MagicalItemTraitsGenerator>();
            Bind<IMundaneGearGeneratorFactory>().To<MundaneGearGeneratorFactory>();
            Bind<IMundaneItemGenerator>().To<MundaneItemGenerator>();
            Bind<ISpecialAbilitiesGenerator>().To<SpecialAbilitiesGenerator>();
            Bind<ISpecialMaterialGenerator>().To<SpecialMaterialGenerator>();
            Bind<ISpecificGearGenerator>().To<SpecificGearGenerator>();
            Bind<ISpellGenerator>().To<SpellGenerator>();
            Bind<IToolGenerator>().To<ToolGenerator>();
            Bind<ITreasureGenerator>().To<TreasureGenerator>();
        }
    }
}