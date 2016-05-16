using Ninject.Modules;
using TreasureGen.Coins;
using TreasureGen.Domain.Generators;
using TreasureGen.Domain.Generators.Coins;
using TreasureGen.Domain.Generators.Goods;
using TreasureGen.Domain.Generators.Items;
using TreasureGen.Domain.Generators.Items.Magical;
using TreasureGen.Domain.Generators.Items.Mundane;
using TreasureGen.Domain.IoC.Providers;
using TreasureGen.Domain.Items.Mundane;
using TreasureGen.Generators;
using TreasureGen.Goods;
using TreasureGen.Items;
using TreasureGen.Items.Magical;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Domain.IoC.Modules
{
    internal class GeneratorsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAmmunitionGenerator>().To<AmmunitionGenerator>();
            Bind<IChargesGenerator>().To<ChargesGenerator>();
            Bind<ICoinGenerator>().To<CoinGenerator>();
            Bind<ICurseGenerator>().To<CurseGenerator>();
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

            Bind<MundaneItemGenerator>().ToProvider(new MundaneItemGeneratorProvider(ItemTypeConstants.Tool)).Named(ItemTypeConstants.Tool);
            Bind<MundaneItemGenerator>().ToProvider(new MundaneItemGeneratorProvider(ItemTypeConstants.AlchemicalItem)).Named(ItemTypeConstants.AlchemicalItem);
            Bind<MundaneItemGenerator>().ToProvider(new MundaneItemGeneratorProvider(ItemTypeConstants.Armor)).Named(ItemTypeConstants.Armor);
            Bind<MundaneItemGenerator>().ToProvider(new MundaneItemGeneratorProvider(ItemTypeConstants.Weapon)).Named(ItemTypeConstants.Weapon);

            Bind<MagicalItemGenerator>().ToProvider(new MagicalItemGeneratorProvider(ItemTypeConstants.Armor)).Named(ItemTypeConstants.Armor);
            Bind<MagicalItemGenerator>().ToProvider(new MagicalItemGeneratorProvider(ItemTypeConstants.Potion)).Named(ItemTypeConstants.Potion);
            Bind<MagicalItemGenerator>().ToProvider(new MagicalItemGeneratorProvider(ItemTypeConstants.Ring)).Named(ItemTypeConstants.Ring);
            Bind<MagicalItemGenerator>().ToProvider(new MagicalItemGeneratorProvider(ItemTypeConstants.Rod)).Named(ItemTypeConstants.Rod);
            Bind<MagicalItemGenerator>().ToProvider(new MagicalItemGeneratorProvider(ItemTypeConstants.Scroll)).Named(ItemTypeConstants.Scroll);
            Bind<MagicalItemGenerator>().ToProvider(new MagicalItemGeneratorProvider(ItemTypeConstants.Staff)).Named(ItemTypeConstants.Staff);
            Bind<MagicalItemGenerator>().ToProvider(new MagicalItemGeneratorProvider(ItemTypeConstants.Wand)).Named(ItemTypeConstants.Wand);
            Bind<MagicalItemGenerator>().ToProvider(new MagicalItemGeneratorProvider(ItemTypeConstants.Weapon)).Named(ItemTypeConstants.Weapon);
            Bind<MagicalItemGenerator>().ToProvider(new MagicalItemGeneratorProvider(ItemTypeConstants.WondrousItem)).Named(ItemTypeConstants.WondrousItem);
        }
    }
}