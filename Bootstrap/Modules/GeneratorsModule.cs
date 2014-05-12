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

            Bind<IMundaneItemGenerator>().To<ToolGenerator>().Named(ItemTypeConstants.Tool);
            Bind<IMundaneItemGenerator>().To<AlchemicalItemGenerator>().Named(ItemTypeConstants.AlchemicalItem);
            Bind<IMundaneItemGenerator>().To<MundaneArmorGenerator>().Named(ItemTypeConstants.Armor);
            Bind<IMundaneItemGenerator>().ToMethod(c => c.Kernel.Get<IMundaneItemGeneratorFactory>().CreateGeneratorOf(ItemTypeConstants.Weapon))
                .Named(ItemTypeConstants.Weapon);

            Bind<IMagicalItemGenerator>().To<MagicalArmorGenerator>().Named(ItemTypeConstants.Armor);
            Bind<IMagicalItemGenerator>().To<MagicalWeaponGenerator>().Named(ItemTypeConstants.Weapon);
            Bind<IMagicalItemGenerator>().To<PotionGenerator>().Named(ItemTypeConstants.Potion);
            Bind<IMagicalItemGenerator>().To<RingGenerator>().Named(ItemTypeConstants.Ring);
            Bind<IMagicalItemGenerator>().To<RodGenerator>().Named(ItemTypeConstants.Rod);
            Bind<IMagicalItemGenerator>().To<ScrollGenerator>().Named(ItemTypeConstants.Scroll);
            Bind<IMagicalItemGenerator>().To<StaffGenerator>().Named(ItemTypeConstants.Staff);
            Bind<IMagicalItemGenerator>().To<WandGenerator>().Named(ItemTypeConstants.Wand);
            Bind<IMagicalItemGenerator>().To<WondrousItemGenerator>().Named(ItemTypeConstants.WondrousItem);

        }
    }
}