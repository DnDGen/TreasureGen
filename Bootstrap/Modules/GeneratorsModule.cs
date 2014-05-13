using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators;
using EquipmentGen.Generators.Coins;
using EquipmentGen.Generators.Goods;
using EquipmentGen.Generators.Interfaces;
using EquipmentGen.Generators.Interfaces.Coins;
using EquipmentGen.Generators.Interfaces.Goods;
using EquipmentGen.Generators.Interfaces.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Generators.Items;
using EquipmentGen.Generators.Items.Magical;
using EquipmentGen.Generators.Items.Mundane;
using EquipmentGen.Generators.RuntimeFactories;
using EquipmentGen.Generators.RuntimeFactories.Interfaces;
using Ninject;
using Ninject.Modules;

namespace EquipmentGen.Bootstrap.Modules
{
    public class GeneratorsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IChargesGenerator>().To<ChargesGenerator>();
            Bind<ICoinGenerator>().To<CoinGenerator>();
            Bind<ICurseGenerator>().To<CurseGenerator>();
            Bind<IDice>().ToMethod(c => DiceFactory.Create()).InSingletonScope();
            Bind<IGoodsGenerator>().To<GoodsGenerator>();
            Bind<IIntelligenceGenerator>().To<IntelligenceGenerator>();
            Bind<IItemsGenerator>().To<ItemsGenerator>();
            Bind<IMagicalItemGeneratorFactory>().To<MagicalItemGeneratorFactory>();
            Bind<IMagicalItemTraitsGenerator>().To<MagicalItemTraitsGenerator>();
            Bind<IMundaneItemGeneratorFactory>().To<MundaneItemGeneratorFactory>();
            Bind<ISpecialAbilitiesGenerator>().To<SpecialAbilitiesGenerator>();
            Bind<ISpecialMaterialGenerator>().To<SpecialMaterialGenerator>();
            Bind<ISpecificGearGenerator>().To<SpecificGearGenerator>();
            Bind<ISpellGenerator>().To<SpellGenerator>();
            Bind<ITreasureGenerator>().To<TreasureGenerator>();

            Bind<IMundaneItemGenerator>().ToMethod(c => c.Kernel.Get<IMundaneItemGeneratorFactory>().CreateGeneratorOf(ItemTypeConstants.Tool)).Named(ItemTypeConstants.Tool);
            Bind<IMundaneItemGenerator>().ToMethod(c => c.Kernel.Get<IMundaneItemGeneratorFactory>().CreateGeneratorOf(ItemTypeConstants.AlchemicalItem)).Named(ItemTypeConstants.AlchemicalItem);
            Bind<IMundaneItemGenerator>().ToMethod(c => c.Kernel.Get<IMundaneItemGeneratorFactory>().CreateGeneratorOf(ItemTypeConstants.Armor)).Named(ItemTypeConstants.Armor);
            Bind<IMundaneItemGenerator>().ToMethod(c => c.Kernel.Get<IMundaneItemGeneratorFactory>().CreateGeneratorOf(ItemTypeConstants.Weapon)).Named(ItemTypeConstants.Weapon);

            Bind<IMagicalItemGenerator>().ToMethod(c => c.Kernel.Get<IMagicalItemGeneratorFactory>().CreateGeneratorOf(ItemTypeConstants.Armor)).Named(ItemTypeConstants.Armor);
            Bind<IMagicalItemGenerator>().ToMethod(c => c.Kernel.Get<IMagicalItemGeneratorFactory>().CreateGeneratorOf(ItemTypeConstants.Weapon)).Named(ItemTypeConstants.Weapon);
            Bind<IMagicalItemGenerator>().ToMethod(c => c.Kernel.Get<IMagicalItemGeneratorFactory>().CreateGeneratorOf(ItemTypeConstants.Potion)).Named(ItemTypeConstants.Potion);
            Bind<IMagicalItemGenerator>().ToMethod(c => c.Kernel.Get<IMagicalItemGeneratorFactory>().CreateGeneratorOf(ItemTypeConstants.Ring)).Named(ItemTypeConstants.Ring);
            Bind<IMagicalItemGenerator>().ToMethod(c => c.Kernel.Get<IMagicalItemGeneratorFactory>().CreateGeneratorOf(ItemTypeConstants.Rod)).Named(ItemTypeConstants.Rod);
            Bind<IMagicalItemGenerator>().ToMethod(c => c.Kernel.Get<IMagicalItemGeneratorFactory>().CreateGeneratorOf(ItemTypeConstants.Scroll)).Named(ItemTypeConstants.Scroll);
            Bind<IMagicalItemGenerator>().ToMethod(c => c.Kernel.Get<IMagicalItemGeneratorFactory>().CreateGeneratorOf(ItemTypeConstants.Staff)).Named(ItemTypeConstants.Staff);
            Bind<IMagicalItemGenerator>().ToMethod(c => c.Kernel.Get<IMagicalItemGeneratorFactory>().CreateGeneratorOf(ItemTypeConstants.Wand)).Named(ItemTypeConstants.Wand);
            Bind<IMagicalItemGenerator>().ToMethod(c => c.Kernel.Get<IMagicalItemGeneratorFactory>().CreateGeneratorOf(ItemTypeConstants.WondrousItem)).Named(ItemTypeConstants.WondrousItem);

        }
    }
}